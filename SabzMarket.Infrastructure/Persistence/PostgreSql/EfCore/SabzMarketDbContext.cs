using Microsoft.EntityFrameworkCore;
using SabzMarket.Domain.Entities.Buyer;
using SabzMarket.Domain.Entities.CartItems;
using SabzMarket.Domain.Entities.Categorie;
using SabzMarket.Domain.Entities.Chat;
using SabzMarket.Domain.Entities.FeaturedSeller;
using SabzMarket.Domain.Entities.Order;
using SabzMarket.Domain.Entities.Product;
using SabzMarket.Domain.Entities.Seller;
using SabzMarket.Domain.Entities.SmsOtp;
using SabzMarket.Domain.Entities.User;

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
        public DbSet<Buyer> Farmers { get; set; }
        public DbSet<FeaturedSeller> FeaturedSellers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<SmsOtp> smsOtps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SabzMarketDbContext).Assembly);
        }
    }
}