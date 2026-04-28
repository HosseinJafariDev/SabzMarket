using SabzMarket.Application.Common;
using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.SendMessage
{
    public interface ISendMessageUseCase
    {
        Task<OperationResult> ExecuteAsync(SendMessageInputDTO sendMessageInputDTO);
    }
}
