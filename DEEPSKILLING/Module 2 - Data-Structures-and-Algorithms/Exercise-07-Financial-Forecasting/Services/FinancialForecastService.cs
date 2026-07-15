using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise07FinancialForecasting.Models;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise07FinancialForecasting.Services;

/// <summary>
/// Forecasts future values using a recursive approach with memoization.
/// </summary>
public class FinancialForecastService
{
    private readonly Dictionary<int, decimal> _memoizedForecasts = new();

    public decimal ForecastFutureValue(ForecastInput input)
    {
        ArgumentNullException.ThrowIfNull(input);

        ValidateInput(input);
        _memoizedForecasts.Clear();

        return ForecastValueRecursive(input.InitialValue, input.GrowthRates, input.GrowthRates.Length);
    }

    public IReadOnlyList<decimal> ForecastSeries(ForecastInput input)
    {
        ArgumentNullException.ThrowIfNull(input);

        ValidateInput(input);
        _memoizedForecasts.Clear();

        List<decimal> series = new();
        BuildSeriesRecursive(input.InitialValue, input.GrowthRates, input.GrowthRates.Length, series);
        return series;
    }

    private decimal ForecastValueRecursive(decimal currentValue, decimal[] growthRates, int periodCount)
    {
        if (periodCount == 0)
        {
            return currentValue;
        }

        if (_memoizedForecasts.TryGetValue(periodCount, out decimal cachedValue))
        {
            return cachedValue;
        }

        decimal previousValue = ForecastValueRecursive(currentValue, growthRates, periodCount - 1);
        decimal growthFactor = 1 + (growthRates[periodCount - 1] / 100m);
        decimal forecastValue = previousValue * growthFactor;

        _memoizedForecasts[periodCount] = forecastValue;
        return forecastValue;
    }

    private void BuildSeriesRecursive(decimal currentValue, decimal[] growthRates, int periodCount, List<decimal> series)
    {
        if (periodCount == 0)
        {
            return;
        }

        BuildSeriesRecursive(currentValue, growthRates, periodCount - 1, series);
        series.Add(ForecastValueRecursive(currentValue, growthRates, periodCount));
    }

    private static void ValidateInput(ForecastInput input)
    {
        if (input.GrowthRates.Length == 0)
        {
            throw new ArgumentException("At least one growth rate is required.", nameof(input));
        }

        if (input.InitialValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "Initial value cannot be negative.");
        }
    }
}
