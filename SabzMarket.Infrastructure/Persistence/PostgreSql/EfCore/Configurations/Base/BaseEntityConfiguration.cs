using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

public abstract class BaseEntityConfiguration<TEntity,T> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<T>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(x => x.Id);
    }
}