using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;
using RetailInventory.Shared.Models;

const string labTitle = "Lab 13: Query Caching and Tracking Behavior";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var products = await context.Products
    .AsNoTracking()
    .ToListAsync();

Console.WriteLine($"Read-only report returned {products.Count} products.");

var result = new List<Product>();
await foreach (var product in Program.ExpensiveProducts(context, 10000m))
{
    result.Add(product);
}

Console.WriteLine($"Compiled query returned {result.Count} expensive products.");

public static partial class Program
{
    public static readonly Func<AppDbContext, decimal, IAsyncEnumerable<Product>> ExpensiveProducts =
        EF.CompileAsyncQuery((AppDbContext ctx, decimal price) =>
            ctx.Products.Where(p => p.Price > price));
}
