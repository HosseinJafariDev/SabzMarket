using Application.Interfaces.Services;
using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Users.UseCases.CheckUsernameAvailability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Users.UseCases.GetUser
{
    public class GetUserByUserName : IGetUserByUserName
    {
        private readonly IUserRepository _userRepository;
        private readonly IErrorService _errorService;
        private readonly IMapper _mapper;
        public GetUserByUserName(IUserRepository userRepository, IErrorService errorService, IMapper mapper)
        {
            _userRepository = userRepository;
            _errorService = errorService;
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
                var errorResult = await _errorService.LogErrorAsync(ex, GetType().Name);
                return OperationResult<GetUserByUserNameOutputDTO>.Failed(errorResult.Message!.ErrorMessage());
            }

        }
    }
}
