using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Configuration.Repository
{
    public class FeaturedSellerConfiguration : IEntityTypeConfiguration<FeaturedSellerTable>
    {
        public void Configure(EntityTypeBuilder<FeaturedSellerTable> builder)
        {
            builder.ToTable("FeaturedSeller")
                .HasIndex(x => x.SellerId)
                .IsUnique();

            builder
                .HasOne(x => x.Seller)
                .WithMany(x => x.FeaturedSellerTables);

            builder
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}
