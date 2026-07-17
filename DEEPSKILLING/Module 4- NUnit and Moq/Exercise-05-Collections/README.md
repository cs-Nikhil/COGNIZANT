# Exercise 5: Collections Library

## Objective
Work with employee collections, equality overrides, and NUnit collection assertions.

## Folder Structure
```text
Exercise-05-Collections/
  Exercise-05-Collections.sln
  src/
    CollectionsLib/
      CollectionsLib.csproj
      Employee.cs
      EmployeeService.cs
  tests/
    CollectionsLib.Tests/
      CollectionsLib.Tests.csproj
      EmployeeServiceTests.cs
```

## Packages
- .NET 8 SDK
- NUnit 4.6.1
- NUnit3TestAdapter 6.2.0
- Microsoft.NET.Test.Sdk 18.8.1

## How to Run
```powershell
dotnet restore Exercise-05-Collections.sln
dotnet build Exercise-05-Collections.sln
```

## How to Test
```powershell
dotnet test Exercise-05-Collections.sln
```

## Expected Output
- The collections library builds.
- The collection assertion tests pass.
