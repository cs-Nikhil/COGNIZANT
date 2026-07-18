using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 10: Eager, Lazy, and Explicit Loading";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var products = await context.Products
    .Include(p => p.Category)
    .ToListAsync();

Console.WriteLine("Eager loaded products:");
foreach (var item in products)
{
    Console.WriteLine($"{item.Name} - {item.Category.Name}");
}

var product = await context.Products.FirstAsync();
await context.Entry(product).Reference(p => p.Category).LoadAsync();
Console.WriteLine($"Explicit loaded category: {product.Category.Name}");

var lazyProduct = await context.Products.FirstAsync();
Console.WriteLine($"Lazy loaded category: {lazyProduct.Category.Name}");
