namespace FourSeasonsLib.Tests;

[TestFixture]
public class FourSeasonsTests
{
    private SeasonService _seasonService = null!;

    [SetUp]
    public void Setup()
    {
        _seasonService = new SeasonService();
    }

    [TestCase(3, Season.Spring)]
    [TestCase(6, Season.Summer)]
    [TestCase(9, Season.Autumn)]
    [TestCase(12, Season.Winter)]
    public void GetSeason_WhenMonthIsInSeason_ReturnsExpectedSeason(int month, Season expected)
    {
        var result = _seasonService.GetSeason(month);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetSeason_WhenMonthIsOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _seasonService.GetSeason(13));
    }
}
