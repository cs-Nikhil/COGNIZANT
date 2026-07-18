using RetailInventory.Shared.Helpers;

const string labTitle = "Lab 1: Understanding ORM with a Retail Inventory System";
if (LabRunner.IsDryRun(args, labTitle))
{
    return;
}

Console.WriteLine(labTitle);
Console.WriteLine("ORM maps C# classes such as Product and Category to relational tables.");
Console.WriteLine("EF Core improves productivity, maintainability, and abstraction from direct SQL.");
Console.WriteLine("EF Core is cross-platform and supports LINQ, async queries, compiled queries, JSON columns, interceptors, and compiled models.");
Console.WriteLine("Create the app with: dotnet new console -n RetailInventory");
Console.WriteLine("Install packages: Microsoft.EntityFrameworkCore.SqlServer and Microsoft.EntityFrameworkCore.Design");
