using AutoMapper;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.SendMessage
{
    public class SendMessageUseCase : ISendMessageUseCase
    {
        private readonly IMapper _mapper;
        private readonly IChatRepository _chatRepository;

        public SendMessageUseCase(IMapper mapper, IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> ExecuteAsync(SendMessageInputDTO sendMessageInputDTO,
            CancellationToken token)
        {
            var chat = _mapper.Map<Chat>(sendMessageInputDTO);
            await _chatRepository.InsertAsync(chat, token);

            return OperationResult.Success(OperationError.Success);
        }
    }
}