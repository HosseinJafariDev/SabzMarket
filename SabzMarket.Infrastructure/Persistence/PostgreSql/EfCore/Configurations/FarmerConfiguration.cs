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
    public class FarmerConfiguration : IEntityTypeConfiguration<FarmerTable>
    {
        public void Configure(EntityTypeBuilder<FarmerTable> builder)
        {
            builder.ToTable("Farmer")
                .HasOne(f => f.User)
                .WithOne(u => u.Farmer)
                .HasForeignKey<FarmerTable>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Address)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder
                .Property(x => x.DataBuilt)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(x => x.LandArea)
                .IsRequired();

            builder
                .Property(x => x.NationalCode)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(10);

            builder
                .Property(x => x.CodParvaneBHB)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.ProfileImage)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder
                .Property(x => x.CodePosti)
                .IsRequired()
                .HasColumnType("char(10");
        }
    }
}
