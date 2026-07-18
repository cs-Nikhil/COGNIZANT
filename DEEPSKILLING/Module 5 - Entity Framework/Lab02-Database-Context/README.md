# Lab 2: Setting Up the Database Context for a Retail Store

## Scenario

The retail store stores product and category data in SQL Server.

## Implemented

- `Category` model.
- `Product` model.
- `AppDbContext` with `Products` and `Categories` DbSets.
- SQL Server configuration through `UseSqlServer`.
- Optional connection override through `RETAIL_INVENTORY_CONNECTION`.

## Commands

```powershell
dotnet run --project .\Lab02-Database-Context.csproj
```
