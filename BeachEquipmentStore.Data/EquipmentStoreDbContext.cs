namespace BeachEquipmentStore.Data
{
    using BeachEquipmentStore.Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EquipmentStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public EquipmentStoreDbContext(DbContextOptions<EquipmentStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<AddressLog> AddressLogs { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductLog> ProductLogs { get; set; } = null!;
        public DbSet<ProductOrder> ProductOrders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasSequence<int>("UniqueNumberSeq")
                .StartsAt(1)
                .IncrementsBy(1);

            builder.Entity<Order>()
                .Property(p => p.Number)
                .HasDefaultValueSql("NEXT VALUE FOR UniqueNumberSeq")
                .IsRequired();

            builder.Entity<Order>()
                .HasIndex(p => p.Number)
                .IsUnique();

            builder.Entity<Product>()
                .HasIndex(b => b.Barcode)
                .IsUnique();

            builder.Entity<Order>()
                .HasOne(o => o.AddressLog)
                .WithOne(al => al.Order)
                .HasForeignKey<Order>(o => o.AddressLogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductOrder>()
                .HasOne(po => po.ProductLog)
                .WithOne(pl => pl.ProductOrder)
                .HasForeignKey<ProductOrder>(po => po.ProductLogId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}