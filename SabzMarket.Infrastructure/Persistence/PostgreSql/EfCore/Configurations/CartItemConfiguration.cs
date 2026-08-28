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
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemTable>
    {
        public void Configure(EntityTypeBuilder<CartItemTable> builder)
        {
            builder.ToTable("CartItem");

            builder
                .HasOne(x => x.Farmer)
                .WithMany(x => x.CartItemTables)
                .HasForeignKey(x => x.FarmerId);

            builder.
                HasOne(x => x.Product)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
