namespace BeachEquipmentStore.Data
{
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Data.Models.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class EquipmentStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public EquipmentStoreDbContext(DbContextOptions<EquipmentStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
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

            builder.SeedUsers();
            builder.SeedAddresses();
            builder.SeedCategories();
            builder.SeedManufacturers();
            builder.SeedProducts();

            base.OnModelCreating(builder);
        }
    }
}