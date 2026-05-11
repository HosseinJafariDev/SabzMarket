using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class CategorieConfiguration : IEntityTypeConfiguration<CategorieTable>
    {
        public void Configure(EntityTypeBuilder<CategorieTable> builder)
        {
            builder.ToTable("Categorie")
                .HasData(
                new CategorieTable { Id = 1, Name = "کود های شیمیایی" },
                new CategorieTable { Id = 2, Name = "کود های آلی " },
                new CategorieTable { Id = 3, Name = "کودهای بیولوژیک" },
                new CategorieTable { Id = 4, Name = "حشره کش ها " },
                new CategorieTable { Id = 5, Name = "علف کش ها" },
                new CategorieTable { Id = 6, Name = "سموم معدنی " },
                new CategorieTable { Id = 7, Name = "سموم آلی " }
                );

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
        }
    }
}
