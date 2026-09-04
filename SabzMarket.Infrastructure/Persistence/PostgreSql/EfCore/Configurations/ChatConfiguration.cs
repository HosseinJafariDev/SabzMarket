using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Entities.Chats;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class ChatConfiguration : BaseEntityConfiguration<Chat, long>
    {
        public override void Configure(EntityTypeBuilder<Chat> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("Chat")
                .HasOne(c => c.FromUser)
                .WithMany()
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.ToUser)
                .WithMany()
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(c => c.SenderId)
                .HasDatabaseName("IX_Chats_FromUserId");

            builder
                .HasIndex(c => c.ReceiverId)
                .HasDatabaseName("IX_Chats_ToUserId");

            builder
                .Property(x => x.Message)
                .HasColumnType("nvarchar(max)");
        }
    }
}