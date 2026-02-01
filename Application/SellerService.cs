using SabzMarket.Share;
using SabzMarket.Share.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Share.ViewModels;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Models;
using Application.Interfaces.Services;
using System.Net.WebSockets;
using SabzMarket.Application.Interfaces.Repository;

namespace SabzMarket.Application
{
    public class SellerService : ISellerService
    {
        private readonly IErrorService _errorService;
        private readonly ISellerRepository _sellerRepository;
        private readonly IUserService _userService;
        public SellerService(ISellerRepository sellerRepository, IErrorService errorService, IUserService userService)
        {
            _sellerRepository = sellerRepository;
            _errorService = errorService;
            _userService = userService;
        }

        public async Task<OperationResult> CheckUserExistsInSellerAsync(string username)
        {
            var result = await _sellerRepository.UserExistsInSellerAsync(username);
            if(!result.Success)
            {
                if(!result.Result)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult.FailedResult();
            }
            return OperationResult.SuccessedResult();
        }

        public async Task<OperationResult> CreateSelllerAsync(SellerPartialViewModel sellerViewMode2)
        {
            if (!sellerViewMode2.IsValid)
            {
                return OperationResult.FailedResult(sellerViewMode2.ErrorMessage);
            }
            using var savePhoto = new SavePhoto();
            var result2 = await savePhoto.SaveAsync(sellerViewMode2.ProfileImage!);
            if(!result2.Success)
            {
                var error = result2.Exception!.ExceptionToErrorDTO(result2.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }
            sellerViewMode2.ProfileImage = result2.Message!;
            var sellerViewModel1 = sellerViewMode2.SellerPartialViewModelToSellerFullViewModel();
            var result = await _sellerRepository.InsertAsync(sellerViewModel1.ToSellerDTO());
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, Messages.successSignUp2);
        }

        public async Task<OperationResult<SellerFullViewModel>> GetByIdAsync(long phone)
        {
            var result=await _sellerRepository.SelectByIdAsync(phone);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult<SellerFullViewModel>.Failed(resultError.Message!.ErrorMessage());
            }
            var seller = result.Data.ToSellerFullViewModel();
            return OperationResult<SellerFullViewModel>.SuccessedResult(seller);
        }

        public async Task<OperationResult<List<SellerFullViewModel>>> GetByPhoneNumberAsync(string id)
        {
            var result=await _sellerRepository.SelectByPhoneNumberAsync(id);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult=await _errorService.LogErrorAsync(error);
                OperationResult<List<SellerFullViewModel>>.Failed(errorResult.Message!.ErrorMessage());
            }
            List<SellerFullViewModel> seller = result.Data.Select(x => x.ToSellerFullViewModel()).ToList();
            return OperationResult<List<SellerFullViewModel>>.SuccessedResult(seller);
        }

        public async Task<OperationResult<SellerFullViewModel>> GetSellerByUsernameAsync(string username)
        {
            var result = await _sellerRepository.SelectByUsernameAsync(username);
            if(!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult<SellerFullViewModel>.Failed(result1.Message!.ErrorMessage());
            }
            var seller = result.Data.ToSellerFullViewModel();
            return OperationResult<SellerFullViewModel>.SuccessedResult(seller);
        }



        public async Task<OperationResult> UpdateAsync(string username, UserViewModel userViewModel, SellerPartialViewModel sellerPartialViewModel)
        {
            if (!userViewModel.IsValid)
            {
                return OperationResult.FailedResult(userViewModel.ErrorMessage);
            }
            if (!sellerPartialViewModel.IsValid)
            {
                return OperationResult.FailedResult(sellerPartialViewModel.ErrorMessage);
            }
            if (!sellerPartialViewModel.ProfileImage!.Contains(Messages.Url))
            {
                using var savePhoto = new SavePhoto();
                var result3 = await savePhoto.SaveAsync(sellerPartialViewModel.ProfileImage);
                if (!result3.Success)
                {
                    var error = result3.Exception!.ExceptionToErrorDTO(result3.Message!);
                    var result4 = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result4.Message!.ErrorMessage());
                }
                sellerPartialViewModel.ProfileImage = result3.Message!;
                if (username != userViewModel.UserName)
                {
                    var result1 = await _userService
                                             .IsUsernameAvailableAsync(userViewModel.UserName!);
                    if (!result1.Success)
                    {
                        if (!result1.Result)
                        {
                            var error = result1.Exception!.ExceptionToErrorDTO(result1.Message!);
                            var resultt = await _errorService.LogErrorAsync(error);
                            return OperationResult.Failed(resultt.Message!.ErrorMessage());
                        }
                        var resultUp1 = await _sellerRepository
                                        .UpdateAsync(userViewModel.ToUserDTO(), sellerPartialViewModel.SellerPartialViewModelToSellerFullViewModel().ToSellerDTO());
                        if (!resultUp1.Success)
                        {
                            var error = resultUp1.Exception!.ExceptionToErrorDTO(resultUp1.Message!);
                            var result2 = await _errorService.LogErrorAsync(error);
                            return OperationResult.Failed(result2.Message!.ErrorMessage());
                        }
                        return OperationResult.SuccessedResult(true, Messages.update);

                    }
                    return OperationResult.FailedResult(Messages.existingUser);
                }
                var resultUp2 = await _sellerRepository
                                .UpdateAsync(userViewModel.ToUserDTO(), sellerPartialViewModel.SellerPartialViewModelToSellerFullViewModel().ToSellerDTO());
                if (!resultUp2.Success)
                {
                    var error = resultUp2.Exception!.ExceptionToErrorDTO(resultUp2.Message!);
                    var result2 = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result2.Message!.ErrorMessage());
                }
                return OperationResult.SuccessedResult(true, Messages.update);
            }
            if (username != userViewModel.UserName)
            {
                var result1 = await _userService
                                         .IsUsernameAvailableAsync(userViewModel.UserName!);
                if (!result1.Success)
                {
                    if (!result1.Result)
                    {
                        var error = result1.Exception!.ExceptionToErrorDTO(result1.Message!);
                        var resultt = await _errorService.LogErrorAsync(error);
                        return OperationResult.Failed(resultt.Message!.ErrorMessage());
                    }
                    var resultUp1 = await _sellerRepository
                                    .UpdateAsync( userViewModel.ToUserDTO(), sellerPartialViewModel.SellerPartialViewModelToSellerFullViewModel().ToSellerDTO());
                    if (!resultUp1.Success)
                    {
                        var error = resultUp1.Exception!.ExceptionToErrorDTO(resultUp1.Message!);
                        var result2 = await _errorService.LogErrorAsync(error);
                        return OperationResult.Failed(result2.Message!.ErrorMessage());
                    }
                    return OperationResult.SuccessedResult(true, Messages.update);
                }
                return OperationResult.FailedResult(Messages.existingUser);
            }
            var result = await _sellerRepository
                                   .UpdateAsync(userViewModel.ToUserDTO(), sellerPartialViewModel.SellerPartialViewModelToSellerFullViewModel().ToSellerDTO());
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result2 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result2.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, Messages.update);
        }
    }
}
