namespace UrlHostNameParser.Tests;

[TestFixture]
public class UrlHostNameParserTests
{
    private UrlHostNameParser _parser = null!;

    [SetUp]
    public void SetUp()
    {
        _parser = new UrlHostNameParser();
    }

    [TearDown]
    public void TearDown()
    {
        _parser = null!;
    }

    [Test]
    public void ParseHostName_WhenGivenValidUrl_ReturnsHostName()
    {
        var result = _parser.ParseHostName("https://www.example.com/path/resource");

        Assert.That(result, Is.EqualTo("www.example.com"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("this-is-not-a-url")]
    [TestCase("ftp://example.com")]
    public void ParseHostName_WhenInputIsInvalid_ReturnsNull(string? url)
    {
        var result = _parser.ParseHostName(url);

        Assert.That(result, Is.Null);
    }
}
