using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise07FinancialForecasting.Models;
using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise07FinancialForecasting.Services;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise07FinancialForecasting;

public static class Program
{
    public static void Main()
    {
        var forecastService = new FinancialForecastService();

        Console.WriteLine("Financial Forecasting");
        Console.WriteLine("Enter the initial value:");
        decimal initialValue = ReadDecimal();

        Console.WriteLine("Enter historical growth rates as comma-separated percentages (example: 5,3,4):");
        decimal[] growthRates = ReadGrowthRates();

        var input = new ForecastInput
        {
            InitialValue = initialValue,
            GrowthRates = growthRates
        };

        decimal futureValue = forecastService.ForecastFutureValue(input);
        IReadOnlyList<decimal> forecastSeries = forecastService.ForecastSeries(input);

        Console.WriteLine();
        Console.WriteLine("Forecast Results:");
        for (int index = 0; index < forecastSeries.Count; index++)
        {
            Console.WriteLine($"Period {index + 1}: {forecastSeries[index]:F2}");
        }

        Console.WriteLine($"Future Value after {growthRates.Length} periods: {futureValue:F2}");
    }

    private static decimal ReadDecimal()
    {
        while (true)
        {
            Console.Write("> ");

            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                return value;
            }

            Console.WriteLine("Invalid number. Please enter a valid decimal value.");
        }
    }

    private static decimal[] ReadGrowthRates()
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }

            string[] parts = input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            List<decimal> growthRates = new();
            bool isValid = true;

            foreach (string part in parts)
            {
                if (decimal.TryParse(part, out decimal rate))
                {
                    growthRates.Add(rate);
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid && growthRates.Count > 0)
            {
                return growthRates.ToArray();
            }

            Console.WriteLine("Invalid format. Please enter comma-separated decimal values like 5,3,4.");
        }
    }
}
