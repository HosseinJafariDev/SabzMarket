using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.UseCases.Chats.findUsersChatted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.QueryServices
{
    public class ChatQueryService : IChatQueryService
    {
        private readonly SabzMarketDbContext _dbContext;
        public ChatQueryService(SabzMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<findUsersChattedOutputDTO>> findUsersChattedWith(long id)
        {
            var result = await _dbContext
                .Chats
                .AsNoTracking()
                .Where(x => x.FromUserId == id || x.ToUserId == id)
                .Select(x => new findUsersChattedOutputDTO()
                {
                    Id = x.FromUserId == id ? x.ToUser!.Id : x.FromUser!.Id,
                    Firstname = x.FromUserId == id ? x.ToUser!.FirstName : x.FromUser!.FirstName,
                    Lastname = x.FromUserId == id ? x.ToUser!.LastName : x.FromUser!.LastName,
                    Username = x.FromUserId == id ? x.ToUser!.UserName : x.FromUser!.UserName,
                })
                .ToListAsync();
            return result;
        }
    }
}
