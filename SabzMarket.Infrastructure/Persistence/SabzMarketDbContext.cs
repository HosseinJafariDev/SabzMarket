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
            modelBuilder.Entity<CategorieTable>().ToTable("Categorie")
                .HasData(
                new CategorieTable { Id = 1, Name = "کود های شیمیایی" },
                new CategorieTable { Id = 2, Name = "کود های آلی " },
                new CategorieTable { Id = 3, Name = "کودهای بیولوژیک" },
                new CategorieTable { Id = 4, Name = "حشره کش ها " },
                new CategorieTable { Id = 5, Name = "علف کش ها" },
                new CategorieTable { Id = 6, Name = "سموم معدنی " },
                new CategorieTable { Id = 7, Name = "سموم آلی " }
                );
            modelBuilder.Entity<SellerTable>().ToTable("Seller")
                .HasOne(s => s.User)
                .WithOne(u => u.Seller)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FarmerTable>().ToTable("Farmer")
                .HasOne(f => f.User)
                .WithOne(u => u.Farmer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetailTable>().ToTable("OrderDetail")
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ChatTable>().ToTable("Chat")
                .HasOne(c => c.FromUser)
                .WithMany()
                .HasForeignKey(c => c.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChatTable>()
                .HasOne(c => c.ToUser)
                .WithMany()
                .HasForeignKey(c => c.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FeaturedSellerTable>().ToTable("FeaturedSeller")
                .HasIndex(x => x.SellerId)
                .IsUnique();

            modelBuilder.Entity<UserTable>().ToTable("User");

            modelBuilder.Entity<CartItemTable>().ToTable("CartItem");

            modelBuilder.Entity<ErrorTable>().ToTable("Error");

            modelBuilder.Entity<OrderTable>().ToTable("Order");

            modelBuilder.Entity<ProductTable>().ToTable("Product");

        }
    }
}
