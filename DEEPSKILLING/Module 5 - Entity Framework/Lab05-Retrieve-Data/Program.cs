using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 5: Retrieving Data from the Database";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var products = await context.Products.ToListAsync();
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - Rs.{p.Price}");
}

var product = await context.Products.FindAsync(1);
Console.WriteLine($"Found: {product?.Name}");

var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000m);
Console.WriteLine($"Expensive: {expensive?.Name}");
