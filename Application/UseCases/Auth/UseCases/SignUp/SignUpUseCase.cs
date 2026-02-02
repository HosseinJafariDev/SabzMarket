using Application.Interfaces.Services;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Auth.Mappers;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UseCases.SignUp
{
    public class SignUpUseCase : ISignUpUseCase
    {
        private readonly SignUpValidator _validator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IErrorService _errorService;
        public SignUpUseCase(SignUpValidator validator, IUserRepository userRepository, IMapper mapper, IErrorService errorService)
        {
            _validator = validator;
            _userRepository = userRepository;
            _mapper = mapper;
            _errorService = errorService;
        }
        public async Task<OperationResult> ExecuteAsync(SignUpInputDTO input)
        {
            try
            {
                var validationResult = _validator.Validate(input);
                if (!validationResult.IsValid)
                    return OperationResult.FailedResult(validationResult.Errors.First().ErrorMessage);

                var resultCheckUser = await _userRepository.CheckUserAsync(input.UserName!);
                if (!resultCheckUser)
                {
                    return OperationResult.FailedResult(Messages.ExistingUserName);
                }
                var user = _mapper.Map<User>(input);
                await _userRepository.InsertAsync(user);
                return OperationResult.SuccessedResult(true, Messages.SignUpSuccessful);
            }
            catch (Exception ex)
            {
                var result = await _errorService.LogErrorAsync(ex, GetType().Name);
                return OperationResult.Failed(result.Message!.ErrorMessage());
            }

        }
    }
}
