# Lab 10: Eager, Lazy, and Explicit Loading

## Scenario

The store dashboard needs products with their categories.

## Implemented

- Eager loading with `Include(p => p.Category)`.
- Explicit loading with `Entry(product).Reference(p => p.Category).LoadAsync()`.
- Lazy loading through `Microsoft.EntityFrameworkCore.Proxies`, `UseLazyLoadingProxies()`, and `virtual` navigation properties.

## Commands

```powershell
dotnet run --project .\Lab10-Loading-Strategies.csproj
```
