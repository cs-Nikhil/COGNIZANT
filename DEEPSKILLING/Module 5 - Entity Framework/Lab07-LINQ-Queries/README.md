# Lab 7: Writing Queries with LINQ

## Scenario

The store filters and sorts products for reporting.

## Implemented

- `Where(p => p.Price > 1000)`.
- `OrderByDescending(p => p.Price)`.
- Projection into anonymous DTO values with `Select`.

## Commands

```powershell
dotnet run --project .\Lab07-LINQ-Queries.csproj
```
