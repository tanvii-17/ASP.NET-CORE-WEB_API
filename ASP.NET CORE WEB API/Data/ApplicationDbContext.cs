using ASP.NET_CORE_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .HasDatabaseName("IX_Product_Name")  //configures name of Index in DB
                .IsUnique(false);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", Price = 699.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Price = 999.99m, CategoryId = 1 },
                new Product { Id = 3, Name = "Novel", Price = 15.99m, CategoryId = 2 },
                new Product { Id = 4, Name = "T-Shirt", Price = 19.99m, CategoryId = 3 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
