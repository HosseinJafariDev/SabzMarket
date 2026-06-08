using AutoMapper;
using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Auth.Mappers;
using SabzMarket.Application.UseCases.Sellers.CreateSeller;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Application.UseCases.Auth.SignUp
{
    public class SignUpUseCase : ISignUpUseCase
    {
        private readonly IValidator<SignUpInputDTO> _validator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISmsOtpRepository _smsOtpRepository;

        public SignUpUseCase(
            IValidator<SignUpInputDTO> validator,
            IUserRepository userRepository,
            IMapper mapper,
            ISmsOtpRepository smsOtpRepository)
        {
            _validator = validator;
            _userRepository = userRepository;
            _mapper = mapper;
            _smsOtpRepository = smsOtpRepository;
        }

        public async Task<OperationResult> ExecuteAsync(SignUpInputDTO input, CancellationToken token)
        {
            var validationResult = _validator.Validate(input);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult.Errors.First().ErrorMessage);

            if (input.Otp == 0)
                throw new BadRequestException(Messages.EnterOtp);

            var resultCheckUser = await _userRepository.CheckUserAsync(input.UserName!, token);
            if (resultCheckUser)
                throw new BadRequestException(Messages.ExistingUserName);

            var reuslt = await _smsOtpRepository.VerifyOtp(input.OtpId, input.Otp, token);
            if (!reuslt)
                throw new BadRequestException(Messages.InvalidOtp);

            var user = _mapper.Map<User>(input);
            await _userRepository.InsertAsync(user, token);

            return OperationResult.Success(OperationError.None, Messages.SignUpSuccessful);
        }
    }
}