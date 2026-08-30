using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Entities.CartItems;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class CartItemConfiguration : BaseEntityConfiguration<CartItem, int>
    {
        public override void Configure(EntityTypeBuilder<CartItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("CartItem");

            builder
                .HasOne(x => x.Farmer)
                .WithMany(x => x.CartItemTables)
                .HasForeignKey(x => x.FarmerId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.ProductId);
        }
    }
}