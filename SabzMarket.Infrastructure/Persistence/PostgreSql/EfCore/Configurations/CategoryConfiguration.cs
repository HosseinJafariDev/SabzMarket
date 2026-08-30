using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Constants;
using SabzMarket.Domain.Entities.Categories;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category, long>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categorie")
                .HasData(
                    new Category(1, "کود های شیمیایی"),
                    new Category(2, "کود های آلی "),
                    new Category(3, "کودهای بیولوژیک"),
                    new Category(4, "حشره کش ها "),
                    new Category(5, "علف کش ها"),
                    new Category(6, "سموم معدنی "),
                    new Category(7, "سموم آلی ")
                );

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(CategoryConstants.NameMaxLength);
        }
    }
}