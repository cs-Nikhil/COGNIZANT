using System;

namespace ConverterLib
{
    public interface IExchangeRateProvider
    {
        decimal GetRate(string fromCurrency, string toCurrency);
    }

    public class CurrencyConverter
    {
        private readonly IExchangeRateProvider _exchangeRateProvider;

        public CurrencyConverter(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            var rate = _exchangeRateProvider.GetRate(fromCurrency, toCurrency);
            return amount * rate;
        }
    }
}
