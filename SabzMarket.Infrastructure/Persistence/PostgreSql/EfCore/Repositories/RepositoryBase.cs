using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Repositories;

public abstract class RepositoryBase<TEntity, TKey>(SabzMarketDbContext context)
    : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<TEntity?> GetByIdAsync(TKey id,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool tracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(
            x => x.Id!.Equals(id),
            cancellationToken);
    }

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? where = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool tracking = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (where != null)
        {
            query = query.Where(where);
        }

        if (orderBy != null)
        {
            if (!tracking)
                return await orderBy(query).AsNoTracking().ToListAsync();
            else
                return await orderBy(query).ToListAsync();
        }
        else
        {
            if (!tracking)
                return await query.AsNoTracking().ToListAsync();
            else
                return await query.ToListAsync();
        }
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