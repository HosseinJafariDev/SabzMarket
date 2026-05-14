using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly SabzMarketDbContext _dbContext;
        public ChatRepository(SabzMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Chat>> GetChatAsync(long fromId, long toId, CancellationToken token)
        {
            var result = await _dbContext
                .Chats
                .AsNoTracking()
                .Where(x => x.FromUserId == fromId && x.ToUserId == toId || x.FromUserId == toId && x.ToUserId == fromId)
                .Select(x => new Chat()
                {
                    Id = x.Id,
                    FromUserId = x.FromUserId,
                    ToUserId = x.ToUserId,
                    IsDeleted = x.IsDeleted,
                    IsFile = x.IsFile,
                    IsRead = x.IsRead,
                    Message = x.Message,
                    SentAt = x.SentAt
                }).ToListAsync(token);
            return result;
        }

        public async Task InsertAsync(Chat chat, CancellationToken token)
        {
            var table = new ChatTable()
            {
                Id = chat.Id,
                FromUserId = chat.FromUserId,
                ToUserId = chat.ToUserId,
                IsDeleted = chat.IsDeleted,
                IsFile = chat.IsFile,
                IsRead = chat.IsRead,
                Message = chat.Message,
                SentAt = chat.SentAt
            };
            await _dbContext.Chats.AddAsync(table);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
