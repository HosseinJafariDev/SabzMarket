namespace SabzMarket.Application.Interfaces.Persistence;

public interface IRepository<TEntity, in TKey> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}