using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECom.Models;
using Microsoft.AspNetCore.Identity;

namespace ECom.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            // modelBuilder.Entity<Category>()
            //     .HasMany(c => c.Products)
            //     .WithOne(p => p.Category)
            //     .HasForeignKey(p => p.CategoryId);
            // modelBuilder.Entity<Manufacture>()
            //     .HasMany(c => c.Products)
            //     .WithOne(p => p.Manufacture)
            //     .HasForeignKey(p => p.ManufactureId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Specification)
                .WithOne(s => s.Product)
                .HasForeignKey<Specification>(s=>s.ProductId);
            // modelBuilder.Entity<Basket>()
            //     .HasMany(b => b.Items)
            //     .WithOne(i => i.Basket)
            //     .HasForeignKey(i => i.BasketId);
            // modelBuilder.Entity<BasketItem>()
            //     .HasOne(b=>b.Product)
            //     .WithMany();
            // modelBuilder.Entity<OrderStatus>()
            //     .HasMany(os => os.Orders)
            //     .WithOne(o => o.OrderStatus)
            //     .HasForeignKey(o => o.OrderStatusId);
            // modelBuilder.Entity<Order>()
            //     .HasMany(o => o.OrderItems)
            //     .WithOne(oi => oi.Order)
            //     .HasForeignKey(oi => oi.OrderId);
            // modelBuilder.Entity<OrderItem>()
            //     .HasOne(oi => oi.Product)
            //     .WithMany();
            modelBuilder.Entity<OrderItem>()
                .OwnsOne(x=>x.ItemOrdered);
            modelBuilder.Entity<Order>()
                .OwnsOne(x=>x.ShipToAddress);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Basket> Baskets {get; set;}
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } 
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}