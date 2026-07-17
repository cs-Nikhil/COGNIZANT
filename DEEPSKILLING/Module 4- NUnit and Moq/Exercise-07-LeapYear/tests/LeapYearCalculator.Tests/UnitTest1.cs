namespace LeapYearCalculator.Tests;

[TestFixture]
public class LeapYearCalculatorTests
{
    private LeapYearCalculator _calculator = null!;

    [SetUp]
    public void Setup()
    {
        _calculator = new LeapYearCalculator();
    }

    [TestCase(2020, true)]
    [TestCase(2021, false)]
    [TestCase(2000, true)]
    [TestCase(1900, false)]
    public void IsLeapYear_WhenGivenYear_ReturnsExpectedResult(int year, bool expected)
    {
        var result = _calculator.IsLeapYear(year);

        Assert.That(result, Is.EqualTo(expected));
    }
}
