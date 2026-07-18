# Lab 8: Managing Migrations and Schema Changes

## Scenario

The store adds `StockQuantity` to track inventory levels.

## Implemented

- `Product.StockQuantity`.
- `AddStockQuantity` migration class.
- CLI commands for schema update.

## Commands

```powershell
dotnet ef migrations add AddStockQuantity
dotnet ef database update
```
