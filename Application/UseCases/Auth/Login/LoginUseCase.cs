using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Auth.Login
{
    public class LoginUseCase(
        IUserRepository userRepository,
        ITokenService tokenService,
        IPasswordHasher passwordHasher) : ILoginUseCase
    {
        public async Task<string> ExecuteAsync(LoginInputDto input, CancellationToken token)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.UserName) || string.IsNullOrWhiteSpace(input.Password))
                throw new BadRequestException(Messages.EnterUsernameAndPassword);

            var user = await userRepository.GetByUserNameAsync(input.UserName, token);

            if (user == null || !passwordHasher.Verify(input.Password, user.UserName!))
                throw new BadRequestException(Messages.InvalidPasswordAndUsername);


            var jwtToken = tokenService.GenerateToken(user!);

            return jwtToken;
        }
    }
}