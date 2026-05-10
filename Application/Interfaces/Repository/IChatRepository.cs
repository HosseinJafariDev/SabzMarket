using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IChatRepository
    {
        Task<List<Chat>> GetChatAsync(long fromId, long toId, CancellationToken token);
        Task InsertAsync(Chat chat, CancellationToken token);
    }
}
