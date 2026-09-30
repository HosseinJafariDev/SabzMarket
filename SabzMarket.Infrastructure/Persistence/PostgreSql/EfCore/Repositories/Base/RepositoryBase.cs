using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Base;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore;

namespace SabzMarket.Infrastructure.Persistence.PostgreSql.EfCore.Repositories.Base;

public abstract class RepositoryBase<TEntity, TKey>(SabzMarketDbContext context)
    : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    protected readonly SabzMarketDbContext Context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<(IReadOnlyList<TEntity> Items, int TotalCount)> GetWithPaginationAsync<TFilter>(
        CancellationToken cancellationToken,
        int skip = 0,
        int take = 10
    )
    {
        IQueryable<TEntity> query = _dbSet;

        int count = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return (items, count);
    }

    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}