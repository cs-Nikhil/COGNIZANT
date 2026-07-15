using System;

namespace ObserverPatternExample.Observers
{
    public class WebApp : IObserver
    {
        private string name;

        public WebApp(string name)
        {
            this.name = name;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"{name} Web App: {stockName} price updated to {price}");
        }
    }
}