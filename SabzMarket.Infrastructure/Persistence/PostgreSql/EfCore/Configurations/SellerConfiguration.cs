using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Constants;
using SabzMarket.Domain.Entities.Sellers;
using SabzMarket.Infrastructure.Entities;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class SellerConfiguration : BaseEntityConfiguration<Seller, long>
    {
        public override void Configure(EntityTypeBuilder<Seller> builder)
        {
            base.Configure(builder);

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
                .HasMaxLength(SellerConstants.WorkHistoryMaxLength);
        }
    }
}