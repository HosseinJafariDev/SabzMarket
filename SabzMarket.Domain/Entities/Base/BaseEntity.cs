namespace SabzMarket.Domain.Entities.Base;

public abstract class BaseEntity<T> : IEntity
{
    public T Id { get; private set; }
}

public abstract class BaseEntity : BaseEntity<long>
{
}