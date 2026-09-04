using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Entities.FeaturedSellers;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class FeaturedSellerConfiguration : BaseEntityConfiguration<FeaturedSeller, int>
    {
        public override void Configure(EntityTypeBuilder<FeaturedSeller> builder)
        {
            base.Configure(builder);

            builder.ToTable("FeaturedSeller")
                .HasIndex(x => x.SellerId)
                .IsUnique();

            builder
                .HasOne(x => x.Seller)
                .WithMany();

            builder
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}