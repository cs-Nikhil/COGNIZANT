
using AdapterPatternExample.Adapters;
using AdapterPatternExample.Gateways;
using AdapterPatternExample.PaymentProcessors;

namespace AdapterPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor paypal =
                new PayPalAdapter(new PayPalGateway());

            paypal.ProcessPayment(1000);

            IPaymentProcessor stripe =
                new StripeAdapter(new StripeGateway());

            stripe.ProcessPayment(2500);
        }
    }
}