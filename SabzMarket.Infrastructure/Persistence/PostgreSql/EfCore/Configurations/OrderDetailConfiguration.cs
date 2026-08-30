using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Constants;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class OrderDetailConfiguration : BaseEntityConfiguration<OrderDetail, long>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderDetail")
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails);

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder
                .Property(x => x.Number)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(OrderDetileConstants.StatusMaxLength);
        }
    }
}