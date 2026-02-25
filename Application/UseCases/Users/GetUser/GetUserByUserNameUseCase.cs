using Application.Interfaces.Services;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.GetUser
{
    public class GetUserByUserNameUseCase : IGetUserByUserNameUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        public GetUserByUserNameUseCase(IUserRepository userRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _errorRepository = errorRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<GetUserByUserNameOutputDTO>> ExecuteAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return OperationResult<GetUserByUserNameOutputDTO>.FailedResult(Messages.UserNameMinLength);

            try
            {
                var result = await _userRepository.SelectByUserNameAsync(username);
                if (result == null)
                {
                    return OperationResult<GetUserByUserNameOutputDTO>.FailedResult(Messages.UserNotFound);
                }
                var userDTO = _mapper.Map<GetUserByUserNameOutputDTO>(result);
                return OperationResult<GetUserByUserNameOutputDTO>.SuccessedResult(userDTO);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<GetUserByUserNameOutputDTO>.Failed(errorResult.ErrorMessage());
            }

        }
    }
}
