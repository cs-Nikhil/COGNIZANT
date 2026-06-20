using System;

namespace DecoratorPatternExample.Notifiers
{
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }
}