using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace SabzMarket.Application.Interfaces.Persistence;

public interface IRepository<TEntity, in TKey> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);

    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    Task<(IReadOnlyList<TEntity> Items, int TotalCount)> GetWithPaginationAsync<TFilter>(
        CancellationToken cancellationToken,
        int skip = 0,
        int take = 10
    );

    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}