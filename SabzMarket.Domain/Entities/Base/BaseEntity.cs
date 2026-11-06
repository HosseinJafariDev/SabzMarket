namespace SabzMarket.Domain.Entities.Base;

public abstract class BaseEntity<T> : IEntity
{
    public T Id { get; protected set; }
    public bool IsActive { get; set; }
}

public abstract class BaseEntity : BaseEntity<long>
{
}