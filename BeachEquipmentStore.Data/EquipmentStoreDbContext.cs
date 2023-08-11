namespace BeachEquipmentStore.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BeachEquipmentStore.Data.Models;
    using System.Reflection;
    using BeachEquipmentStore.Data.Models.Extensions;
    using System.Reflection.Emit;
    using System.Reflection.Metadata;

    public class EquipmentStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public EquipmentStoreDbContext(DbContextOptions<EquipmentStoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Delivery> Delivery { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductOrder> ProductOrders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(EquipmentStoreDbContext)) ??
            Assembly.GetExecutingAssembly();

            builder.Entity<Product>()
                .HasIndex(b => b.Barcode)
                .IsUnique();

            builder.Entity<ProductOrder>()
                .HasKey(p => new { p.OrderId, p.ProductId });

            builder.Entity<CartItem>()
                .HasKey(p => new { p.ProductId, p.CustomerId });

            builder.Entity<Order>()
                .HasOne(d => d.Delivery)
                .WithMany(o => o.Orders)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Invoice>()
                .HasOne(o => o.Order)
                .WithMany(inv => inv.Invoices)
                .HasForeignKey(fk => fk.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.SeedUsers();
            builder.SeedCategories();
            builder.SeedManufacturers();
            builder.SeedProducts();

            base.OnModelCreating(builder);
        }
    }
}