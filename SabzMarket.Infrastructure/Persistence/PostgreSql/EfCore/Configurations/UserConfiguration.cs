using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabzMarket.Domain.Constants;
using SabzMarket.Domain.Entities.Users;
using SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations.Base;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User, long>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("User");

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(UserConstants.FirsNameMaxLength);

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(UserConstants.LastNameMaxLength);

            builder
                .Property(x => x.Phone)
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(UserConstants.PhoneMaxLength);

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(UserConstants.EmailMaxLength);

            builder
                .Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(UserConstants.UserNameMaxLength);

            builder
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnType("nvarchar");
        }
    }
}