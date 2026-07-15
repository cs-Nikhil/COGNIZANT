using System;

namespace ObserverPatternExample.Observers
{
    public class MobileApp : IObserver
    {
        private string name;

        public MobileApp(string name)
        {
            this.name = name;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"{name} Mobile App: {stockName} price updated to {price}");
        }
    }
}