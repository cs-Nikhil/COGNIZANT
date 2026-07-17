namespace ParameterizedCalculator.Tests;

[TestFixture]
public class CalculatorParameterizedTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [TearDown]
    public void TearDown()
    {
        _calculator = null!;
    }

    [TestCase(10, 5, 5)]
    [TestCase(5, 10, -5)]
    [TestCase(-2, -3, 1)]
    public void Subtract_WhenCalled_ReturnsDifference(double firstValue, double secondValue, double expectedResult)
    {
        var result = _calculator.Subtract(firstValue, secondValue);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(2, 3, 6)]
    [TestCase(-2, 4, -8)]
    [TestCase(1.5, 2, 3)]
    public void Multiply_WhenCalled_ReturnsProduct(double firstValue, double secondValue, double expectedResult)
    {
        var result = _calculator.Multiply(firstValue, secondValue);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(10, 2, 5)]
    [TestCase(9, 3, 3)]
    [TestCase(-12, 4, -3)]
    public void Divide_WhenCalled_ReturnsQuotient(double dividend, double divisor, double expectedResult)
    {
        var result = _calculator.Divide(dividend, divisor);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Divide_WhenDivisorIsZero_ThrowsArgumentException()
    {
        try
        {
            _calculator.Divide(10, 0);
            Assert.Fail("Expected an ArgumentException when the divisor is zero.");
        }
        catch (ArgumentException exception)
        {
            Assert.That(exception.ParamName, Is.EqualTo("divisor"));
        }
    }

    [Test]
    public void AllClear_WhenCalled_ResetsResultToZero()
    {
        _calculator.Add(25, 5);

        _calculator.AllClear();

        Assert.That(_calculator.GetResult(), Is.EqualTo(0));
    }
}
