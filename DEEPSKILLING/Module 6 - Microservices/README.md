# Module 6 - Microservices

This module contains four JWT authentication and authorization labs for ASP.NET Core Web API microservices.

## Solution

- `Microservices.Module6.sln`

## Labs

- `Lab01-JWT-Authentication` - login endpoint, JWT generation, and a protected endpoint
- `Lab02-Secure-Endpoint` - securing an API endpoint with `[Authorize]`
- `Lab03-Role-Based-Authorization` - role-based authorization using the `Admin` role
- `Lab04-Token-Expiry-Handling` - expired token handling and custom unauthorized responses

## Run

```powershell
dotnet restore
dotnet build
dotnet run --project .\Lab01-JWT-Authentication\Lab01-JWT-Authentication.csproj
dotnet run --project .\Lab02-Secure-Endpoint\Lab02-Secure-Endpoint.csproj
dotnet run --project .\Lab03-Role-Based-Authorization\Lab03-Role-Based-Authorization.csproj
dotnet run --project .\Lab04-Token-Expiry-Handling\Lab04-Token-Expiry-Handling.csproj
```

## Sample users

- `admin` / `Admin@123`
- `user` / `User@123`
