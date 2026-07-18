# Lab 5: Retrieving Data from the Database

## Scenario

The dashboard displays product details.

## Implemented

- `ToListAsync` retrieves all products.
- `FindAsync(1)` finds by primary key.
- `FirstOrDefaultAsync(p => p.Price > 50000)` finds an expensive product.

## Commands

```powershell
dotnet run --project .\Lab05-Retrieve-Data.csproj
```
