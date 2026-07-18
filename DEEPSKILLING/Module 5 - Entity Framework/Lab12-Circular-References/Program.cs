using Microsoft.EntityFrameworkCore;
using RetailInventory.Shared.Data;
using RetailInventory.Shared.DTOs;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 12: Navigating Circular References";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();

var productDTOs = await context.Products
    .Select(p => new ProductDto
    {
        Name = p.Name,
        CategoryName = p.Category.Name
    })
    .ToListAsync();

foreach (var dto in productDTOs)
{
    Console.WriteLine($"{dto.Name} - {dto.CategoryName}");
}
