using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Configuration.Repository
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderTable>
    {
        public void Configure(EntityTypeBuilder<OrderTable> builder)
        {
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
