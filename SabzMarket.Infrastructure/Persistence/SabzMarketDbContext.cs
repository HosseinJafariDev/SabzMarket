using Microsoft.EntityFrameworkCore;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence
{
    public class SabzMarketDbContext : DbContext
    {
        public SabzMarketDbContext(DbContextOptions<SabzMarketDbContext> options) : base(options)
        {
        }


        public DbSet<UserTable> Users { get; set; }
        public DbSet<SellerTable> Sellers { get; set; }
        public DbSet<ProductTable> Products { get; set; }
        public DbSet<OrderTable> Orders { get; set; }
        public DbSet<CategorieTable> Categories { get; set; }
        public DbSet<ChatTable> Chats { get; set; }
        public DbSet<OrderDetailTable> OrderDetails { get; set; }
        public DbSet<FarmerTable> Farmers { get; set; }
        public DbSet<ErrorTable> ErrorLogs { get; set; }
        public DbSet<FeaturedSellerTable> FeaturedSellers { get; set; }
        public DbSet<CartItemTable> CartItems { get; set; }
        public DbSet<SmsOtpTable> smsOtps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SabzMarketDbContext).Assembly);
        }
    }
}
