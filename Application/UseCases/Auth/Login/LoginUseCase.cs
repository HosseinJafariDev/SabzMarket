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
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginUseCase(
            IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<OperationResult<string>> ExecuteAsync(LoginInputDTO input, CancellationToken token)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.UserName) || string.IsNullOrWhiteSpace(input.Password))
                throw new BadRequestException(Messages.EnterUsernameAndPassword);

            var user = await _userRepository.SelectByUserNameForLoginAsync(input.UserName!, token);

            if (user == null || !user.VerifyPassword(input.Password!))
                throw new BadRequestException(Messages.InvalidPasswordAndUsername);

            var userr = _userRepository.SelectByUserNameAsync(input.UserName, token).Result;

            var jwtToken = _tokenService.GenerateToken(userr!);

            return OperationResult<string>.Success(jwtToken, OperationError.Success);
        }
    }
}