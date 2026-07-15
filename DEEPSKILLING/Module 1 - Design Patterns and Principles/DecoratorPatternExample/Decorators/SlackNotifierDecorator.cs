using System;
using DecoratorPatternExample.Notifiers;

namespace DecoratorPatternExample.Decorators
{
    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(INotifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("Slack: " + message);
        }
    }
}