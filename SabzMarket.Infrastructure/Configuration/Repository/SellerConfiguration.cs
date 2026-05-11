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
            builder.ToTable("Seller");

            builder
                   .HasOne(s => s.User)
                   .WithOne(u => u.Seller)
                   .HasForeignKey<SellerTable>(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(X => X.Address)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder
                .Property(x => x.ProfileImage)
                .HasColumnType("nvarchar(max)");

            builder
                .Property(x => x.WorkHistory)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(3);
        }
    }
}
