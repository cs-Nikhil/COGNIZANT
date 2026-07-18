using RetailInventory.Shared.Data;
using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 2: Setting Up the Database Context for a Retail Store";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

using var context = new AppDbContext();
Console.WriteLine(labTitle);
Console.WriteLine($"Products DbSet configured: {context.Products.EntityType.Name}");
Console.WriteLine($"Categories DbSet configured: {context.Categories.EntityType.Name}");
Console.WriteLine("Connection string can be overridden with RETAIL_INVENTORY_CONNECTION.");
