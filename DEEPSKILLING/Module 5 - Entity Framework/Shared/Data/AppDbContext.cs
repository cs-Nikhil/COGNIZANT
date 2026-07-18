using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Models;

namespace RetailInventory.Shared.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("RETAIL_INVENTORY_CONNECTION")
            ?? "Server=(localdb)\\MSSQLLocalDB;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True";

        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Groceries" });

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Smartphone", Price = 25000m, CategoryId = 1, StockQuantity = 50 },
            new Product { Id = 2, Name = "Wheat Flour", Price = 800m, CategoryId = 2, StockQuantity = 100 });

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductDetail)
            .WithOne(pd => pd.Product)
            .HasForeignKey<ProductDetail>(pd => pd.ProductId);

        modelBuilder.Entity<Tag>().HasData(
            new Tag { Id = 1, Name = "On Sale" },
            new Tag { Id = 2, Name = "New Arrival" });
    }
}
