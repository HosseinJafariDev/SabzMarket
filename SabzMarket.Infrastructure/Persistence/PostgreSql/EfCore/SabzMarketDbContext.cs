using Microsoft.EntityFrameworkCore;
using SabzMarket.Domain.Entities.CartItems;
using SabzMarket.Domain.Entities.Categories;
using SabzMarket.Domain.Entities.Chats;
using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Domain.Entities.FeaturedSellers;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Domain.Entities.Sellers;
using SabzMarket.Domain.Entities.SmsOtps;
using SabzMarket.Domain.Entities.Users;

namespace SabzMarket.Infrastructure.Persistence.Postgresql.EfCore
{
    public class SabzMarketDbContext : DbContext
    {
        public SabzMarketDbContext(DbContextOptions<SabzMarketDbContext> options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<FeaturedSeller> FeaturedSellers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<SmsOtp> smsOtps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SabzMarketDbContext).Assembly);
        }
    }
}