using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
using SabzMarket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SabzMarketDbContext _context;
        public UserRepository(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserAsync(string username)
        {
            var result = await _context
                .Users
                .AsNoTracking()
                .AnyAsync(u => u.UserName == username);
            return result;
        }

        public Task<User?> SelectByUserNameForLoginAsync(string userName)
        {
            var result = _context
                .Users
                .AsNoTracking()
                .Where(x => x.UserName == userName).Select(x => new User()
                {
                    UserName = x.UserName,
                    Password = x.Password
                })
                .SingleOrDefaultAsync();
            return result;
        }

        public async Task InsertAsync(User user)
        {
            UserTable userTable = new UserTable
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            };
            _context.Users
                .Add(userTable);
            await _context
                .SaveChangesAsync();
        }

        public async Task<User> SelectByUserNameAsync(string username)
        {
            var result = await _context.Users
             .AsNoTracking()
             .Where(u => u.UserName == username)
             .Select(u => new User
             {
                 UserName = u.UserName!,
                 Email = u.Email!,
                 FirstName = u.FirstName!,
                 LastName = u.LastName!,
                 Phone = u.Phone!,
                 Id = u.Id,
                 Password = u.Password!

             })
             .SingleOrDefaultAsync();
            return result!;
        }

        public async Task UpdateAsync(User user)
        {
            var userTable = new UserTable { Id = user.Id };
            _context.Attach(userTable);
            userTable.UserName = user.UserName;
            userTable.Password = user.Password;
            userTable.FirstName = user.FirstName;
            userTable.LastName = user.LastName;
            userTable.Email = user.Email;
            userTable.Phone = user.Phone;

            var entryUser = _context.Entry(userTable);
            entryUser.Property(x => x.UserName).IsModified = true;
            entryUser.Property(x => x.Password).IsModified = true;
            entryUser.Property(x => x.FirstName).IsModified = true;
            entryUser.Property(x => x.LastName).IsModified = true;
            entryUser.Property(x => x.Email).IsModified = true;
            entryUser.Property(x => x.Phone).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}