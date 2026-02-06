using Application.Interfaces.Services;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.CheckUsernameAvailability
{
    public class CheckUsernameAvailabilityUseCase : ICheckUsernameAvailabilityUseCase
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IUserRepository _userRepository;
        public CheckUsernameAvailabilityUseCase(IUserRepository userRepository, IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
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
                var errorResult = await _errorRepository.LogErrorAsync(ex, GetType().Name);
                return OperationResult.Failed(errorResult.ErrorMessage());
            }

        }
    }
}
