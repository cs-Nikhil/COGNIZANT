# Lab 13: Query Caching and Tracking Behavior

## Scenario

The store runs frequent read-only reports and wants better query performance.

## Implemented

- `AsNoTracking()` for read-only reports.
- Compiled query using `EF.CompileAsyncQuery`.

## Commands

```powershell
dotnet run --project .\Lab13-Query-Caching-Tracking.csproj
```
