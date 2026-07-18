# Lab 3: Using EF Core CLI to Create and Apply Migrations

## Scenario

Create the retail store database from the EF Core models.

## Implemented

- Initial migration class for `Categories`, `Products`, `ProductDetails`, `Tags`, and the product-tag join table.
- CLI command documentation for creating and applying migrations.

## Commands

```powershell
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```
