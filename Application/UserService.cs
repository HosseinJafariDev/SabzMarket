using Application.Interfaces.Services;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Share;
using SabzMarket.Share.ErrorHandling;
using SabzMarket.Share.Mappers;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SabzMarket.Application
{
    public class UserService : IUserService
    {
        private readonly IErrorService _errorService;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IErrorService errorService) 
        {
            _userRepository = userRepository;
            _errorService = errorService;
        }

        public async Task<OperationResult<UserViewModel>> GetUserAsync(string username)
        {
            var result=await _userRepository.SelectAsync(username);
            if(!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult<UserViewModel>.Failed(result1.Message!.ErrorMessage());
            }
            var data = result.Data.ToUserViewModel();
            return OperationResult<UserViewModel>.SuccessedResult(data);
        }

        public async Task<OperationResult> IsUsernameAvailableAsync(string username)
        {
            var result = await _userRepository.CheckUserAsync(username);
            if (!result.Success)
            {
                if(!result.Result)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult.FailedResult();
            }
            return OperationResult.SuccessedResult(true, Messages.existingUser);

            
        }

        public async Task<OperationResult> LoginAsync(UserViewModel userViewModel)
        {
            var result=await _userRepository.ChangePasswordAsync(userViewModel.ToUserDTO());
            if (!result.Success)
            {
                if(!result.Result)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1=await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult.FailedResult(Messages.userNotLogin);
            }
            return OperationResult.SuccessedResult();
            
        }

        public async Task<OperationResult> SignUpAsync(UserViewModel userViewModel)
        {
            if(!userViewModel.IsValid)
            {
                return OperationResult.FailedResult(userViewModel.ErrorMessage);
            }
            var result = await _userRepository.CheckUserAsync(userViewModel.UserName!);
            if (!result.Success)
            {
                if(!result.Result)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result1.Message!.ErrorMessage());
                }
                var user = userViewModel.ToUserDTO();
                var result2 = await _userRepository.InsertAsync(user);
                if(!result2.Success)
                {
                    var error = result2.Exception!.ExceptionToErrorDTO(result2.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult.SuccessedResult(true, Messages.successSignUp1);
            }
            return OperationResult.FailedResult(Messages.existingUser);
        }
    }
}
