namespace CalculatorBasic.Tests;

[TestFixture]
public class CalculatorTests
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

    [TestCase(10, 5, 15)]
    [TestCase(-2, 8, 6)]
    [TestCase(1.5, 2.5, 4.0)]
    public void Add_WhenCalled_ReturnsSum(double firstValue, double secondValue, double expectedResult)
    {
        var result = _calculator.Add(firstValue, secondValue);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void AllClear_WhenCalled_ResetsResultToZero()
    {
        _calculator.Add(10, 5);

        _calculator.AllClear();

        Assert.That(_calculator.GetResult(), Is.EqualTo(0));
    }
}
