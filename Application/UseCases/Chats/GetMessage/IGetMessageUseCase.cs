using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.GetMessage
{
    public interface IGetMessageUseCase
    {
        Task<OperationResult<List<GetMessageOutputDTO>>> ExecuteAsync(long fromId, long toId, CancellationToken token);
    }
}
