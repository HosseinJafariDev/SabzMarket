using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Users;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;
using SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories;

public class UserRepository(SabzMarketDbContext context) : RepositoryBase<User, long>(context), IUserRepository
{
    public async Task<User?> GetByUserNameAsync(string useName, CancellationToken token)
    {
        var user = await Context.Users.FirstOrDefaultAsync(x => x.UserName == useName, token);
        return user;
    }
}