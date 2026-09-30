using Microsoft.EntityFrameworkCore.Storage;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories
{
    public class UnitOfWork(SabzMarketDbContext context) : IUnitOfWork
    {
        private IDbContextTransaction? _contextTransaction;

        public async Task BeginAsync()
        {
            _contextTransaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_contextTransaction != null)
                await _contextTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_contextTransaction != null)
                await _contextTransaction.RollbackAsync();
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await context.SaveChangesAsync(token);
        }
    }
}