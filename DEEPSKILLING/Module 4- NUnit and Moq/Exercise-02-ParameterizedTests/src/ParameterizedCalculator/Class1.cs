namespace ParameterizedCalculator;

public class Calculator
{
    private double _result;

    public double Add(double firstValue, double secondValue)
    {
        _result = firstValue + secondValue;
        return _result;
    }

    public double Subtract(double firstValue, double secondValue)
    {
        _result = firstValue - secondValue;
        return _result;
    }

    public double Multiply(double firstValue, double secondValue)
    {
        _result = firstValue * secondValue;
        return _result;
    }

    public double Divide(double dividend, double divisor)
    {
        if (divisor == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.", nameof(divisor));
        }

        _result = dividend / divisor;
        return _result;
    }

    public void AllClear()
    {
        _result = 0;
    }

    public double GetResult()
    {
        return _result;
    }
}
