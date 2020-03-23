using Crow.Shop.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Crow.Shop.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<Product>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<Product>()
                .HasMany(x => x.OptionGroups)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<ProductOptionGroup>()
                .HasMany(x => x.Options)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId);

            builder.Entity<ProductOptionGroup>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.ProductOptionGroup)
                .HasForeignKey(x => x.ProductOptionGroupId);

            builder.Entity<ProductOption>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.ProductOption)
                .HasForeignKey(x => x.ProductOptionId);

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
    }
}
