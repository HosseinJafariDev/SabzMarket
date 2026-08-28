using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailTable>
    {
        public void Configure(EntityTypeBuilder<OrderDetailTable> builder)
        {
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
                .HasMaxLength(50);
        }
    }
}
