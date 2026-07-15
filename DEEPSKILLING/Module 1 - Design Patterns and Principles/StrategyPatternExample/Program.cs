using StrategyPatternExample.Context;
using StrategyPatternExample.Strategies;

namespace StrategyPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext();

            context.SetStrategy(new CreditCardPayment());
            context.ExecutePayment(1000);

            context.SetStrategy(new PayPalPayment());
            context.ExecutePayment(2000);
        }
    }
}