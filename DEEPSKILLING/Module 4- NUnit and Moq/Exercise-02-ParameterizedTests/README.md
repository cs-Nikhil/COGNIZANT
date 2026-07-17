# Exercise 2: Parameterized Calculator Tests

## Objective
Extend calculator coverage with parameterized NUnit tests for subtraction, multiplication, division, division-by-zero, and `AllClear`.

## Folder Structure
```text
Exercise-02-ParameterizedTests/
  Exercise-02-ParameterizedTests.sln
  src/
    ParameterizedCalculator/
      ParameterizedCalculator.csproj
      Calculator.cs
  tests/
    ParameterizedCalculator.Tests/
      ParameterizedCalculator.Tests.csproj
      CalculatorParameterizedTests.cs
```

## Packages
- .NET 8 SDK
- NUnit 4.6.1
- NUnit3TestAdapter 6.2.0
- Microsoft.NET.Test.Sdk 18.8.1

## How to Run
```powershell
dotnet restore Exercise-02-ParameterizedTests.sln
dotnet build Exercise-02-ParameterizedTests.sln
```

## How to Test
```powershell
dotnet test Exercise-02-ParameterizedTests.sln
```

## Expected Output
- The calculator library compiles.
- All parameterized NUnit tests pass.
