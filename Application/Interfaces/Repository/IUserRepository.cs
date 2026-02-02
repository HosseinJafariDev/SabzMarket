using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task<User> SelectByUserNameAsync(string username);
        Task<User?> SelectByUserNameForLoginAsync(string userName);
        Task<bool> CheckUserAsync(string username);
    }
}
