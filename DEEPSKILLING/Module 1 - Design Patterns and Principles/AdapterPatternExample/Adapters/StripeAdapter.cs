using AdapterPatternExample.Gateways;
using AdapterPatternExample.PaymentProcessors;

namespace AdapterPatternExample.Adapters
{
    public class StripeAdapter : IPaymentProcessor
    {
        private StripeGateway gateway;

        public StripeAdapter(StripeGateway gateway)
        {
            this.gateway = gateway;
        }

        public void ProcessPayment(double amount)
        {
            gateway.Pay(amount);
        }
    }
}