using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 7: Writing Queries with LINQ";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var filtered = await context.Products
    .Where(p => p.Price > 1000m)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

Console.WriteLine("Filtered and sorted products:");
foreach (var product in filtered)
{
    Console.WriteLine($"{product.Name} - Rs.{product.Price}");
}

var productDTOs = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();

Console.WriteLine("Projected DTO values:");
foreach (var dto in productDTOs)
{
    Console.WriteLine($"{dto.Name} - Rs.{dto.Price}");
}
