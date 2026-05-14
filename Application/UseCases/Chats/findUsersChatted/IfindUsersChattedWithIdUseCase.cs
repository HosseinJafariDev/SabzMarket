using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Chats.findUsersChatted
{
    public interface IfindUsersChattedWithIdUseCase
    {
        Task<OperationResult<List<findUsersChattedOutputDTO>>> ExecuteAsync(long id, CancellationToken token);
    }
}
