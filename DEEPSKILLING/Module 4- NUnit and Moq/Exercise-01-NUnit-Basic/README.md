# Exercise 1: NUnit Basic Calculator

## Objective
Build a calculator library and verify the basic `Add` and `AllClear` behaviors with NUnit.

## Folder Structure
```text
Exercise-01-NUnit-Basic/
  Exercise-01-NUnit-Basic.sln
  src/
    CalculatorBasic/
      CalculatorBasic.csproj
      Calculator.cs
  tests/
    CalculatorBasic.Tests/
      CalculatorBasic.Tests.csproj
      CalculatorTests.cs
```

## Packages
- .NET 8 SDK
- NUnit 4.6.1
- NUnit3TestAdapter 6.2.0
- Microsoft.NET.Test.Sdk 18.8.1

## How to Run
```powershell
dotnet restore Exercise-01-NUnit-Basic.sln
dotnet build Exercise-01-NUnit-Basic.sln
```

## How to Test
```powershell
dotnet test Exercise-01-NUnit-Basic.sln
```

## Expected Output
- The solution builds successfully.
- The NUnit calculator tests pass.
