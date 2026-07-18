# Lab 15: Handling Concurrency with RowVersion

## Scenario

Two employees update the same product stock at the same time.

## Implemented

- `Product.RowVersion` with `[Timestamp]`.
- Two separate `AppDbContext` instances simulate concurrent employees.
- `DbUpdateConcurrencyException` is caught and reported.

## Commands

```powershell
dotnet run --project .\Lab15-Concurrency-RowVersion.csproj
```
