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

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductTable>
    {
        public void Configure(EntityTypeBuilder<ProductTable> builder)
        {
            builder
                .ToTable("Product");

            builder
                .HasOne(x => x.Seller)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SellerId);

            builder
                .HasOne(x => x.Categorie)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategorieId);


            builder
                .Property(x => x.ProductName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

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
