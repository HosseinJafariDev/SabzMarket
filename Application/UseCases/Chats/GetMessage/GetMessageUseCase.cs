using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.GetMessage
{
    public class GetMessageUseCase : IGetMessageUseCase
    {
        private readonly IChatRepository _chatRepository;
        private readonly IErrorRepository _errorRepository;
        public readonly IMapper _mapper;
        public GetMessageUseCase(IChatRepository chatRepository, IErrorRepository errorRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _errorRepository = errorRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<List<GetMessageOutputDTO>>> ExecuteAsync(long fromId, long toId, CancellationToken token)
        {
            try
            {
                var result = await _chatRepository.GetChatAsync(fromId, toId, token);
                var chat = _mapper.Map<List<GetMessageOutputDTO>>(result);
                return OperationResult<List<GetMessageOutputDTO>>.Success(chat, OperationError.Success);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<GetMessageOutputDTO>>.Failed(OperationError.ServerError, errorResult);
            }
        }
    }
}
