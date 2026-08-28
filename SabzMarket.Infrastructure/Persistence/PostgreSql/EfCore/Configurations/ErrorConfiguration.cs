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
    public class ErrorConfiguration : IEntityTypeConfiguration<ErrorTable>
    {
        public void Configure(EntityTypeBuilder<ErrorTable> builder)
        {
            builder.ToTable("Error");
        }
    }
}
