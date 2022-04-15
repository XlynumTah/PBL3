using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EComWeb.Models;

namespace EComWeb.Data
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .OwnsOne(x=>x.ItemOrdered);
            modelBuilder.Entity<Order>()
                .OwnsOne(x=>x.ShipToAddress);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Basket> Baskets {get; set;}
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } 
    }
}