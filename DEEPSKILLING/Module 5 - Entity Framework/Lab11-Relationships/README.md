# Lab 11: Configuring One-to-One and Many-to-Many Relationships

## Scenario

The store tracks product details such as warranty info and lets products belong to multiple tags.

## Implemented

- `ProductDetail` one-to-one relationship with `Product`.
- `Tag` many-to-many relationship with `Product`.
- Fluent API configuration for the one-to-one foreign key.
- EF Core automatic many-to-many join table.

## Commands

```powershell
dotnet run --project .\Lab11-Relationships.csproj
```
