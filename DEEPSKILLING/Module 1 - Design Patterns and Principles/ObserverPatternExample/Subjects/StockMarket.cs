using System.Collections.Generic;
using ObserverPatternExample.Observers;

namespace ObserverPatternExample.Subjects
{
    public class StockMarket : IStock
    {
        private List<IObserver> observers = new List<IObserver>();
        private string stockName;
        private double price;

        public StockMarket(string stockName)
        {
            this.stockName = stockName;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void DeregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(stockName, price);
            }
        }

        public void SetPrice(double price)
        {
            this.price = price;
            NotifyObservers();
        }
    }
}