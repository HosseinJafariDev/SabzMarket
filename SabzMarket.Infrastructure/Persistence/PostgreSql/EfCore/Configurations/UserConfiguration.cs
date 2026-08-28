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
    public class UserConfiguration : IEntityTypeConfiguration<UserTable>
    {
        public void Configure(EntityTypeBuilder<UserTable> builder)
        {
            builder
                .ToTable("User");

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.Phone)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(11);

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder
                .Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar");
        }
    }
}
