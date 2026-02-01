using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application
{
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IErrorService _errorService;
        private readonly IUserService _userService;
        public FarmerService(IFarmerRepository farmerRepository, IErrorService errorService, IUserService userService)
        {
            _farmerRepository = farmerRepository;
            _errorService = errorService;
            _userService = userService;
        }
        public async Task<OperationResult> CheckUserExistsInFarmerAsync(string username)
        {
            var result = await _farmerRepository.UserExistsInFarmerAsync(username);
            if (!result.Success)
            {
                if (!result.Result)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var errorResult = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorResult.Message!.ErrorMessage());
                }
                return OperationResult.FailedResult();
            }
            return OperationResult.SuccessedResult();
        }

        public async Task<OperationResult> CreateFarmerAsync(string username, FarmerPartiaViewModel farmer)
        {
            if (!farmer.IsValid)
            {
                OperationResult.FailedResult(farmer.ErrorMessage);
            }
            using var savePhoto = new SavePhoto();
           var resultSave=await savePhoto.SaveAsync(farmer.ProfileImage!);
            if (!resultSave.Success)
            {
                var error = resultSave.Exception!.ExceptionToErrorDTO(resultSave.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            farmer.ProfileImage = resultSave.Message;
            var farmerDTO = farmer.ToFarmerDTO();
            var result = await _farmerRepository.InsertAsync(username, farmerDTO);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, Messages.successSignUp2);
        }

        public async Task<OperationResult<FarmerDTO>> GetByUsernameAsync(string username)
        {
            var result = await _farmerRepository.SelectByUsernameAsync(username);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult<FarmerDTO>.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult<FarmerDTO>.SuccessedResult(result.Data);
        }

        public async Task<OperationResult> UpdateAsync(FarmerSummaryViewModel farmerViewModel,string username)
        {
            if (!farmerViewModel.IsValid)
            {
                return OperationResult.FailedResult(farmerViewModel.ErrorMessage);
            }

            if (username != farmerViewModel.UserName)
            {
                var existsUsername = await _userService.IsUsernameAvailableAsync(username);
                if (existsUsername.Success)
                {
                    return OperationResult.FailedResult(Messages.existingUser);
                }
                if (!existsUsername.Result)
                {
                    var error = existsUsername.Exception!.ExceptionToErrorDTO(existsUsername.Message!);
                    var errorResult = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorResult.Message!.ErrorMessage());
                }
            }

            if (farmerViewModel.ProfileImage!.Contains(Messages.Url))
            {
                var farmer = farmerViewModel.ToFarmerDTO();
                var result = await _farmerRepository.UpdateAsync(farmer);
                if (!result.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var errorResult= await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorResult.Message!.ErrorMessage());
                }
                return OperationResult.SuccessedResult(true,Messages.update);
            }

            using var savePhoto =new SavePhoto();
            var resultSavePhoto = await savePhoto.SaveAsync(farmerViewModel.ProfileImage);
            if (!resultSavePhoto.Success)
            {
                var error = resultSavePhoto.Exception!.ExceptionToErrorDTO(resultSavePhoto.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }

            farmerViewModel.ProfileImage = resultSavePhoto.Message;
            var farmerDTO = farmerViewModel.ToFarmerDTO();
            var reusltUpdate = await _farmerRepository.UpdateAsync(farmerDTO);
            if (!reusltUpdate.Success)
            {
                var error = resultSavePhoto.Exception!.ExceptionToErrorDTO(resultSavePhoto.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }

            return OperationResult.SuccessedResult(true, Messages.update);
        }
    }
}
