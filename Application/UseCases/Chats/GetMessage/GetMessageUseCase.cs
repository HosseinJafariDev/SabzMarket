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
        public readonly IMapper _mapper;

        public GetMessageUseCase(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<GetMessageOutputDTO>>> ExecuteAsync(long fromId, long toId,
            CancellationToken token)
        {
            var result = await _chatRepository.GetChatAsync(fromId, toId, token);
            var chat = _mapper.Map<List<GetMessageOutputDTO>>(result);

            return OperationResult<List<GetMessageOutputDTO>>.Success(chat, OperationError.Success);
        }
    }
}