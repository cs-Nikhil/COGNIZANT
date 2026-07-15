using ObserverPatternExample.Observers;

namespace ObserverPatternExample.Subjects
{
    public interface IStock
    {
        void RegisterObserver(IObserver observer);
        void DeregisterObserver(IObserver observer);
        void NotifyObservers();
    }
}