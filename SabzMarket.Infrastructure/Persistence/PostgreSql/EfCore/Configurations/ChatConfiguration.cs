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
    public class ChatConfiguration : IEntityTypeConfiguration<ChatTable>
    {
        public void Configure(EntityTypeBuilder<ChatTable> builder)
        {
            builder
                .ToTable("Chat")
                .HasOne(c => c.FromUser)
                .WithMany()
                .HasForeignKey(c => c.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.ToUser)
                .WithMany()
                .HasForeignKey(c => c.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(c => c.FromUserId)
                .HasDatabaseName("IX_Chats_FromUserId");

            builder
                .HasIndex(c => c.ToUserId)
                .HasDatabaseName("IX_Chats_ToUserId");

            builder
                .Property(x => x.Message)
                .HasColumnType("nvarchar(max)");
        }
    }
}
