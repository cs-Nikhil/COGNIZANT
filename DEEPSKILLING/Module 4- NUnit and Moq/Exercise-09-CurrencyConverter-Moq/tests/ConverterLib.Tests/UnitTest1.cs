using Moq;

namespace ConverterLib.Tests;

[TestFixture]
public class CurrencyConverterTests
{
    [Test]
    public void Convert_WhenRateProviderReturnsRate_ReturnsConvertedAmount()
    {
        var rateProvider = new Mock<IExchangeRateProvider>();
        rateProvider.Setup(provider => provider.GetRate("USD", "EUR")).Returns(0.92m);

        var converter = new CurrencyConverter(rateProvider.Object);

        var result = converter.Convert(100m, "USD", "EUR");

        Assert.That(result, Is.EqualTo(92m));
        rateProvider.Verify(provider => provider.GetRate("USD", "EUR"), Times.Once);
    }
}
