using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Constants;
using SabzMarket.Infrastructure.Entities;
using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class FarmerConfiguration : BaseEntityConfiguration<Farmer, long>
    {
        public override void Configure(EntityTypeBuilder<Farmer> builder)
        {
            base.Configure(builder);

            builder.ToTable("Farmer")
                .HasOne(f => f.User)
                .WithOne(u => u.Farmer)
                .HasForeignKey<FarmerTable>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(x => x.Address)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(FarmerConstants.AddressMaxLength);

            builder
                .Property(x => x.DataBuilt)
                .IsRequired()
                .HasMaxLength(FarmerConstants.DataBuiltMaxLength);

            builder
                .Property(x => x.LandArea)
                .IsRequired();

            builder
                .Property(x => x.NationalCode)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(FarmerConstants.NationalCodeMaxLength);

            builder
                .Property(x => x.CodeParvaneBhb)
                .IsRequired()
                .HasColumnType("varchar(14)");

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