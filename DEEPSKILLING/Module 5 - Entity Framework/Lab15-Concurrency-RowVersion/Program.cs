using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 15: Handling Concurrency with RowVersion";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

await using var firstContext = new AppDbContext();
await using var secondContext = new AppDbContext();

var firstEmployeeProduct = await firstContext.Products.FirstAsync();
var secondEmployeeProduct = await secondContext.Products.FirstAsync();

firstEmployeeProduct.StockQuantity += 5;
await firstContext.SaveChangesAsync();

secondEmployeeProduct.StockQuantity += 2;

try
{
    await secondContext.SaveChangesAsync();
    Console.WriteLine("Second update saved.");
}
catch (DbUpdateConcurrencyException)
{
    Console.WriteLine("Concurrency conflict detected.");
}
