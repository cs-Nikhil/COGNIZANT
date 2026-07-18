using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 14: Batch Processing and Bulk Operations";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var productList = await context.Products.ToListAsync();
foreach (var product in productList)
{
    product.StockQuantity += 10;
}

await context.BulkUpdateAsync(productList);
Console.WriteLine($"Bulk updated stock quantities for {productList.Count} products.");
