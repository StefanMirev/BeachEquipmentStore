namespace BeachEquipmentStore.Data
{
    using BeachEquipmentStore.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class EquipmentStoreDbContext : DbContext
    {
        public EquipmentStoreDbContext(DbContextOptions<EquipmentStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CustomerUser> CustomerUsers { get; set; } = null!;
        public DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<UserToken> UserTokens { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<AddressLog> AddressLogs { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductLog> ProductLogs { get; set; } = null!;
        public DbSet<ProductOrder> ProductOrders { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                var updatedAt = entry.Properties.FirstOrDefault(p => p.Metadata.Name == "UpdatedAt");
                if (updatedAt == null) continue;

                bool hasRealChanges = entry.Properties
                    .Any(p => p.Metadata.Name != "UpdatedAt" && p.IsModified);

                if (hasRealChanges)
                    updatedAt.CurrentValue = DateTime.Now;
                else
                    updatedAt.IsModified = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User unique constraints
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // CustomerUser: shared PK — Id is both the PK of CustomerUser and the FK to Users.Id
            builder.Entity<User>()
                .HasOne(u => u.AdminUser)
                .WithOne(a => a.User)
                .HasForeignKey<AdminUser>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            // AdminUser: shared PK — same pattern
            builder.Entity<User>()
                .HasOne(u => u.CustomerUser)
                .WithOne(c => c.User)
                .HasForeignKey<CustomerUser>(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);

            // UserRole: prevent deletion if still assigned to any user
            builder.Entity<UserRole>()
                .HasIndex(r => r.Name)
                .IsUnique();
            builder.Entity<CustomerUser>()
                .HasOne(cu => cu.UserRole)
                .WithMany()
                .HasForeignKey(cu => cu.UserRoleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<AdminUser>()
                .HasOne(au => au.UserRole)
                .WithMany()
                .HasForeignKey(au => au.UserRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserToken: composite index for efficient lookups
            builder.Entity<UserToken>()
                .HasIndex(t => new { t.UserId, t.Type });

            // Order: restrict deletion of CustomerUser while orders exist (preserve history)
            builder.Entity<Order>()
                .HasOne(o => o.CustomerUser)
                .WithMany(cu => cu.Orders)
                .HasForeignKey(o => o.CustomerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order sequence and unique number
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
