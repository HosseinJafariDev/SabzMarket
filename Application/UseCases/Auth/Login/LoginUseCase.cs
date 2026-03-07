using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.Login
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IErrorRepository _errorRepository;
        public LoginUseCase(IErrorRepository errorRepository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _errorRepository = errorRepository;
        }
        public async Task<OperationResult> ExecuteAsync(LoginInputDTO input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.UserName) || string.IsNullOrWhiteSpace(input.Password))
            {
                return OperationResult.FailedResult(Messages.EnterUsernameAndPassword);
            }

            try
            {
                var user = await _userRepository.SelectByUserNameForLoginAsync(input.UserName!);

                if (user == null || !user.VerifyPassword(input.Password!))
                {
                    return OperationResult.FailedResult(Messages.InvalidPasswordAndUsername);
                }
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                var result = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult.Failed(result.ErrorMessage());
            }
        }
    }
}
