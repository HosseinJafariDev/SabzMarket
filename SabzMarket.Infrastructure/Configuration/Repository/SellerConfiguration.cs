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
    public class SellerConfiguration : IEntityTypeConfiguration<SellerTable>
    {
        public void Configure(EntityTypeBuilder<SellerTable> builder)
        {
            builder.ToTable("Seller")
                .HasOne(s => s.User)
                .WithOne(u => u.Seller)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
