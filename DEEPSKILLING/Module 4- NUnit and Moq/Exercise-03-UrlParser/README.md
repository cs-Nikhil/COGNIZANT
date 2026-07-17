# Exercise 3: URL Host Name Parser

## Objective
Parse the host name from a URL and cover the valid, invalid, null, empty, and incorrect-protocol paths with NUnit.

## Folder Structure
```text
Exercise-03-UrlParser/
  Exercise-03-UrlParser.sln
  src/
    UrlHostNameParser/
      UrlHostNameParser.csproj
      UrlHostNameParser.cs
  tests/
    UrlHostNameParser.Tests/
      UrlHostNameParser.Tests.csproj
      UrlHostNameParserTests.cs
```

## Packages
- .NET 8 SDK
- NUnit 4.6.1
- NUnit3TestAdapter 6.2.0
- Microsoft.NET.Test.Sdk 18.8.1

## How to Run
```powershell
dotnet restore Exercise-03-UrlParser.sln
dotnet build Exercise-03-UrlParser.sln
```

## How to Test
```powershell
dotnet test Exercise-03-UrlParser.sln
```

## Expected Output
- The library builds.
- The parser tests pass for all execution paths.
