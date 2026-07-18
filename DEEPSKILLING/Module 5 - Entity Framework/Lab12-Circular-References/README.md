# Lab 12: Navigating Circular References

## Scenario

The store API returns product and category data, but navigation properties can create circular references during serialization.

## Implemented

- `ProductDto` with `Name` and `CategoryName`.
- Projection with `Select` to return DTOs instead of full entity graphs.
- Notes that `[JsonIgnore]` can be used on navigation properties as an alternative.

## Commands

```powershell
dotnet run --project .\Lab12-Circular-References.csproj
```
