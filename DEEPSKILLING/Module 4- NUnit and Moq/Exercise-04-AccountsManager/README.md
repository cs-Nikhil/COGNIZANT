# Exercise 4: Accounts Manager

## Objective
Implement a simple credential check with NUnit coverage for valid, invalid, and null-input login paths.

## Folder Structure
```text
Exercise-04-AccountsManager/
  Exercise-04-AccountsManager.sln
  src/
    AccountsManager/
      AccountsManager.csproj
      AccountsManager.cs
  tests/
    AccountsManager.Tests/
      AccountsManager.Tests.csproj
      AccountsManagerTests.cs
```

## Packages
- .NET 8 SDK
- NUnit 4.6.1
- NUnit3TestAdapter 6.2.0
- Microsoft.NET.Test.Sdk 18.8.1

## How to Run
```powershell
dotnet restore Exercise-04-AccountsManager.sln
dotnet build Exercise-04-AccountsManager.sln
```

## How to Test
```powershell
dotnet test Exercise-04-AccountsManager.sln
```

## Expected Output
- The login library builds.
- All authentication tests pass.
