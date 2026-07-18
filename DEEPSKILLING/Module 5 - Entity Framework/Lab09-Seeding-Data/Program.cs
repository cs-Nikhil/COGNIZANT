using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 9: Seeding Data During Migrations";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

Console.WriteLine(labTitle);
Console.WriteLine("OnModelCreating uses HasData for Electronics, Groceries, Smartphone, and Wheat Flour.");
Console.WriteLine("Create migration: dotnet ef migrations add SeedInitialData");
Console.WriteLine("Apply migration: dotnet ef database update");
