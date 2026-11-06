using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.User;

namespace SabzMarket.Application.Interfaces.Repository;

public interface IUserRepository : IRepository<User, long>
{
    Task<User?> GetByUserNameAsync(string useName, CancellationToken token);
}