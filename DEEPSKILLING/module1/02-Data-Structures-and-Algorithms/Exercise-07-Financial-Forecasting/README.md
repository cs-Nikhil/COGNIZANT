# Exercise 7: Financial Forecasting

## Scenario
You are developing a financial forecasting tool that predicts future values based on past data.

## Objective
Build a C# console application that uses recursion to forecast future values from historical growth rates and explains how to optimize the recursive approach.

## Recursion
Recursion is a problem-solving technique where a function calls itself to solve smaller instances of the same problem.

It can simplify problems that naturally break down into repeated steps, such as applying growth rates period by period.

### Why Recursion Helps
- It makes the forecasting logic easier to follow
- It mirrors the step-by-step growth calculation
- It keeps the implementation compact and readable

## Implementation
This project forecasts future values by applying each growth rate recursively to the previous value.

The application:
- Accepts an initial value
- Accepts historical growth rates as percentages
- Recursively calculates the forecast for each period
- Displays the full forecast series and the final future value

## Project Structure
```text
Module-01/
└── 02-Data-Structures-and-Algorithms/
    └── Exercise-07-Financial-Forecasting/
        ├── FinancialForecasting.csproj
        ├── Program.cs
        ├── Models/
        │   └── ForecastInput.cs
        └── Services/
            └── FinancialForecastService.cs
```

## How to Run
1. Open the project folder in terminal.
2. Run:
```bash
dotnet run
```

## Sample Input
```text
1000
5,3,4
```

## Sample Output
```text
Financial Forecasting
Enter the initial value:
> 1000
Enter historical growth rates as comma-separated percentages (example: 5,3,4):
> 5,3,4

Forecast Results:
Period 1: 1050.00
Period 2: 1081.50
Period 3: 1124.76
Future Value after 3 periods: 1124.76
```

## Time Complexity
- Recursive forecast: `O(n)`
- Forecast series generation: `O(n)`

## Space Complexity
- `O(n)` due to recursion stack and stored forecast values

## How to Optimize the Recursive Solution
The recursive solution can be optimized in these ways:
- Use memoization to cache intermediate results
- Avoid recomputing the same period values repeatedly
- Convert the recursion to an iterative loop if recursion is not required

This implementation already uses memoization so each period value is calculated once.

## Explanation
The recursion starts with the initial value and applies one growth rate at a time until all periods are processed. This makes the forecasting process easy to understand. Because the results are cached, repeated calculations for the same period are avoided.
