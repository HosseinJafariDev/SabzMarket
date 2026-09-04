using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities.Users;

namespace SabzMarket.Application.UseCases.Auth.SignUp
{
    public class SignUpUseCase(
        IUserRepository userRepository,
        ISmsOtpRepository smsOtpRepository,
        IPasswordHasher passwordHasher) : ISignUpUseCase
    {
        public async Task ExecuteAsync(SignUpInputDto input, CancellationToken token)
        {
            if (input.Otp == 0)
                throw new BadRequestException(Messages.EnterOtp);

            var resultCheckUser = await userRepository.GetByUserNameAsync(input.UserName!, token);

            if (resultCheckUser != null)
                throw new BadRequestException(Messages.ExistingUserName);

            var reuslt = await smsOtpRepository.GetByIdAsync(input.OtpId, token);

            if (reuslt == null || reuslt.Otp != input.Otp)
                throw new BadRequestException(Messages.InvalidOtp);

            var passwordHash = passwordHasher.Hash(input.Password);
            // var user = mapper.Map<User>(input);
            // await userRepository.InsertAsync(user, token);
        }
    }
}