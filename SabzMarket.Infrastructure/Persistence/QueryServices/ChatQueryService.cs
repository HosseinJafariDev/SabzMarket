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
        public async Task<List<findUsersChattedOutputDTO>> findUsersChattedWith(long id, CancellationToken token)
        {
            var isFarmer = await _dbContext.Farmers
                .AnyAsync(x => x.UserId == id, token);

            var chats = await _dbContext
                .Chats
                .AsNoTracking()
                .Include(c => c.FromUser)
                .Include(c => c.ToUser)
                .Where(c => c.FromUserId == id || c.ToUserId == id)
                .ToListAsync(token);

            var otherUsers = chats
                .Select(c => c.FromUserId == id ? c.ToUser : c.FromUser)
                .Where(u => u != null)
                .GroupBy(u => u!.Id)
                .Select(g => g.First())
                .ToList();

            var result = otherUsers.Select(u => new findUsersChattedOutputDTO
            {
                Id = u!.Id,
                Firstname = u.FirstName ?? "",
                Lastname = u.LastName ?? "",
                Username = u.UserName ?? "",

                ProfileImage = isFarmer
                    ? u.Seller?.ProfileImage ?? ""
                    : u.Farmer?.ProfileImage ?? ""
            }).ToList();

            //var result = await _dbContext
            //    .Chats
            //    .AsNoTracking()
            //    .Where(c => c.FromUserId == id || c.ToUserId == id)
            //    .Select(c => c.FromUserId == id ? c.ToUser! : c.FromUser!)
            //    .GroupBy(u => u.Id)
            //    .Select(g => g.First())
            //    .Select(u => new findUsersChattedOutputDTO
            //    {
            //        Id = u.Id,
            //        Firstname = u.FirstName,
            //        Lastname = u.LastName,
            //        Username = u.UserName,

            //        ProfileImage = isFarmer
            //            ? u.Seller!.ProfileImage
            //            : u.Farmer!.ProfileImage
            //    })
            //    .ToListAsync();
            return result;
        }
    }
}
