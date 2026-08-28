using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Persistence;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Repositories;

public abstract class RepositoryBase<TEntity, TKey>(SabzMarketDbContext context)
    : IRepository<TEntity, TKey> where TEntity : class
{
    protected readonly SabzMarketDbContext Context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        await _dbSet.FindAsync(id, cancellationToken);
        return _dbSet.Find(id);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
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