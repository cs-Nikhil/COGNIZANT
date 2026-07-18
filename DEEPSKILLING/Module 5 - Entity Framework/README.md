# Module 5 - Entity Framework

This module contains one complete EF Core 8.0 hands-on solution for the Retail Inventory System.

## Solution

- `RetailInventory.Module5.slnx`
- Fifteen lab folders, one for each lab in the EF Core 8.0 HOL document.
- Shared retail inventory model and `AppDbContext` in `Shared/`.

## Database

The projects use SQL Server LocalDB by default:

```powershell
Server=(localdb)\MSSQLLocalDB;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True
```

Override it with:

```powershell
$env:RETAIL_INVENTORY_CONNECTION="Your_Connection_String_Here"
```

## Commands

```powershell
dotnet restore
dotnet build
dotnet run --project .\Lab04-Insert-Initial-Data\Lab04-Insert-Initial-Data.csproj
dotnet ef migrations add InitialCreate --project .\Lab03-Migrations\Lab03-Migrations.csproj
dotnet ef database update --project .\Lab03-Migrations\Lab03-Migrations.csproj
```

Each lab also supports a no-database verification mode:

```powershell
dotnet run --project .\Lab05-Retrieve-Data\Lab05-Retrieve-Data.csproj -- --dry-run
```
