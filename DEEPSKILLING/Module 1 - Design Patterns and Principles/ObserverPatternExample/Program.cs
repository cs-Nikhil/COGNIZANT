using ObserverPatternExample.Subjects;
using ObserverPatternExample.Observers;

namespace ObserverPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            StockMarket stockMarket = new StockMarket("TCS");

            IObserver mobileApp = new MobileApp("Investor");
            IObserver webApp = new WebApp("Trader");

            stockMarket.RegisterObserver(mobileApp);
            stockMarket.RegisterObserver(webApp);

            stockMarket.SetPrice(3500);
            stockMarket.SetPrice(3600);
        }
    }
}