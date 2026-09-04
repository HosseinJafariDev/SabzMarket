using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace SabzMarket.Application.Interfaces.Persistence;

public interface IRepository<TEntity, in TKey> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool tracking = false);

    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? where = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool tracking = false);

    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}