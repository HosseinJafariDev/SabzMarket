using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order, long>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Order");

            builder
                .HasOne(x => x.Seller)
                .WithMany(x => x.Orders);

            builder
                .HasOne(x => x.Farmer)
                .WithMany(x => x.Orders);

            builder
                .Property(x => x.OrderDate)
                .IsRequired();
        }
    }
}