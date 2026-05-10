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
    public class FarmerConfiguration : IEntityTypeConfiguration<FarmerTable>
    {
        public void Configure(EntityTypeBuilder<FarmerTable> builder)
        {
            builder.ToTable("Farmer")
                .HasOne(f => f.User)
                .WithOne(u => u.Farmer)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
