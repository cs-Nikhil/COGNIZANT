namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise07FinancialForecasting.Models;

/// <summary>
/// Represents the input required to forecast future values.
/// </summary>
public class ForecastInput
{
    public decimal InitialValue { get; set; }

    public decimal[] GrowthRates { get; set; } = Array.Empty<decimal>();
}
