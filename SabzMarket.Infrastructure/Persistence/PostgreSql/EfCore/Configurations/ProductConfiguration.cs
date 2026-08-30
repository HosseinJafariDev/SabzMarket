using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SabzMarket.Domain.Constants;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product, long>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("Product");

            builder
                .HasOne(x => x.Seller)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SellerId);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);


            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(ProductConstants.NameMaxLength);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(ProductConstants.DescriptionMaxLength);

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder
                .Property(x => x.Number)
                .IsRequired();

            builder
                .Property(x => x.ImageProduct)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}