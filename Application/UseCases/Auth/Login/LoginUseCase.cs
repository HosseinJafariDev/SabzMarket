using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Auth.Login
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;

        public LoginUseCase(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> ExecuteAsync(LoginInputDTO input, CancellationToken token)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.UserName) || string.IsNullOrWhiteSpace(input.Password))
                throw new BadRequestException(Messages.EnterUsernameAndPassword);

            var user = await _userRepository.SelectByUserNameForLoginAsync(input.UserName!, token);

            if (user == null || !user.VerifyPassword(input.Password!))
                throw new BadRequestException(Messages.InvalidPasswordAndUsername);

            return OperationResult.Success(OperationError.Success);
        }
    }
}