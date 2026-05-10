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
        Task InsertAsync(User user, CancellationToken token);
        Task UpdateAsync(User user, CancellationToken token);
        Task<User> SelectByUserNameAsync(string username, CancellationToken token);
        Task<User?> SelectByUserNameForLoginAsync(string userName, CancellationToken token);
        Task<bool> CheckUserAsync(string username);
    }
}
