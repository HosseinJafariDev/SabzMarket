using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;
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
        private readonly IMapper _mapper;
        public GetUserByUserNameUseCase(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<GetUserByUserNameOutputDTO>> ExecuteAsync(string username, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new BadRequestException(Messages.UserNameMinLength);

            var result = await _userRepository.SelectByUserNameAsync(username, token);
            if (result == null)
            {
                throw new NotFoundException(Messages.UserNotFound);
            }

            var userDTO = _mapper.Map<GetUserByUserNameOutputDTO>(result);
            return OperationResult<GetUserByUserNameOutputDTO>.Success(userDTO, OperationError.Success);
        }
    }
}
