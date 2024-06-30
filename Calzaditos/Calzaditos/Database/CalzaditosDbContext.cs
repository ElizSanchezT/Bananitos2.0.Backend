using Calzaditos.Models;
using Microsoft.EntityFrameworkCore;

namespace Calzaditos.Database
{
    public class CalzaditosDbContext : DbContext
    {
        public CalzaditosDbContext(DbContextOptions<CalzaditosDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<PromoCode> PromoCodes => Set<PromoCode>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RemoveTableNamePluralization(builder);

            builder.Entity<User>(config =>
            {
                config.HasOne(x => x.Cart)
                    .WithOne(x => x.User);
                config.Property(x => x.DeletedAt)
                    .HasColumnType("datetime2");
                config.Property(x => x.CreatedAt)
                    .HasColumnType("datetime2");
            });

            builder.Entity<Cart>(config =>
            {               
                config.Property(x => x.DeletedAt)
                    .HasColumnType("datetime2");
                config.Property(x => x.CreatedAt)
                    .HasColumnType("datetime2");
            });

            builder.Entity<Product>(config =>
            {
                config.Property(x => x.DeletedAt)
                    .HasColumnType("datetime2");
                config.Property(x => x.CreatedAt)
                    .HasColumnType("datetime2");
            });

            builder.Entity<Brand>(config =>
            {
                config.Property(x => x.DeletedAt)
                    .HasColumnType("datetime2");
                config.Property(x => x.CreatedAt)
                    .HasColumnType("datetime2");
            });
            builder.Entity<PromoCode>(config =>
            {
                config.Property(x => x.DeletedAt)
                    .HasColumnType("datetime2");
                config.Property(x => x.CreatedAt)
                    .HasColumnType("datetime2");
            });

            builder.Entity<ProductCart>(config =>
            {
                config.ToTable("Product_Cart");
            });

            builder.Entity<ProductSize>(config =>
            {
                config.ToTable("Product_Size");
            });
        }

        private static void RemoveTableNamePluralization(ModelBuilder builder, params string[] ignore)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                if (entity.IsPropertyBag || entity.IsOwned() || ignore.Contains(entity.DisplayName()))
                {
                    continue;
                }

                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
