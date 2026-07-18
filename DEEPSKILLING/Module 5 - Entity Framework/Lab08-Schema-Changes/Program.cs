using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 8: Managing Migrations and Schema Changes";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

Console.WriteLine(labTitle);
Console.WriteLine("Product model includes public int StockQuantity { get; set; }.");
Console.WriteLine("Create migration: dotnet ef migrations add AddStockQuantity");
Console.WriteLine("Apply migration: dotnet ef database update");
Console.WriteLine("Verify the StockQuantity column in SQL Server.");
