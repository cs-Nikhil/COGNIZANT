using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;
using RetailInventory.Shared.Models;

const string labTitle = "Lab 11: Configuring One-to-One and Many-to-Many Relationships";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var product = await context.Products.Include(p => p.Tags).FirstAsync();
product.ProductDetail ??= new ProductDetail { ProductId = product.Id, WarrantyInfo = "One year warranty" };

var saleTag = await context.Tags.FirstOrDefaultAsync(t => t.Name == "On Sale")
    ?? new Tag { Name = "On Sale" };

if (!product.Tags.Any(t => t.Name == saleTag.Name))
{
    product.Tags.Add(saleTag);
}

await context.SaveChangesAsync();
Console.WriteLine($"Configured details and tags for {product.Name}.");
