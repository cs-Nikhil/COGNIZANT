using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 3: Using EF Core CLI to Create and Apply Migrations";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

Console.WriteLine(labTitle);
Console.WriteLine("Install CLI: dotnet tool install --global dotnet-ef");
Console.WriteLine("Create migration: dotnet ef migrations add InitialCreate");
Console.WriteLine("Apply migration: dotnet ef database update");
Console.WriteLine("Verify Products and Categories tables in SQL Server.");
