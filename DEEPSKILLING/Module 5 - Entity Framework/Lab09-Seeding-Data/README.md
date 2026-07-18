# Lab 9: Seeding Data During Migrations

## Scenario

The store pre-loads categories and products when the database is created.

## Implemented

- `HasData()` seeds `Electronics` and `Groceries`.
- `HasData()` seeds `Smartphone` and `Wheat Flour`.
- `SeedInitialData` migration class.

## Commands

```powershell
dotnet ef migrations add SeedInitialData
dotnet ef database update
```
