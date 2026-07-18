using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;
using RetailInventory.Shared.Models;

const string labTitle = "Lab 4: Inserting Initial Data into the Database";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };
await context.Categories.AddRangeAsync(electronics, groceries);

var product1 = new Product { Name = "Laptop", Price = 75000m, Category = electronics, StockQuantity = 10 };
var product2 = new Product { Name = "Rice Bag", Price = 1200m, Category = groceries, StockQuantity = 25 };
await context.Products.AddRangeAsync(product1, product2);

await context.SaveChangesAsync();
Console.WriteLine("Initial categories and products inserted successfully.");
