# Lab 14: Batch Processing and Bulk Operations

## Scenario

The store updates stock levels for many products after a stock audit.

## Implemented

- `EFCore.BulkExtensions` package reference.
- Loads products, increments stock, and calls `BulkUpdateAsync(productList)`.
- This is the bulk-operation version to compare against a regular `SaveChangesAsync()` loop.

## Commands

```powershell
dotnet run --project .\Lab14-Batch-Bulk-Operations.csproj
```
