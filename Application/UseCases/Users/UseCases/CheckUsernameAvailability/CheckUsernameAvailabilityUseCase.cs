using Application.Interfaces.Services;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Users.UseCases.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.UseCases.CheckUsernameAvailability
{
    public class CheckUsernameAvailabilityUseCase : ICheckUsernameAvailabilityUseCase
    {
        private readonly IErrorService _errorService;
        private readonly IUserRepository _userRepository;
        public CheckUsernameAvailabilityUseCase(IUserRepository userRepository, IErrorService errorService)
        {
            _errorService = errorService;
            _userRepository = userRepository;
        }
        public async Task<OperationResult> ExecuteAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return OperationResult.FailedResult(Messages.UserNameMinLength);

            try
            {
                var result = await _userRepository.CheckUserAsync(username);
                if (result)
                {
                    return OperationResult.SuccessedResult();
                }
                return OperationResult.FailedResult();
            }
            catch (Exception ex)
            {
                var errorResult = await _errorService.LogErrorAsync(ex, GetType().Name);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }

        }
    }
}
