using AdapterPatternExample.Gateways;
using AdapterPatternExample.PaymentProcessors;

namespace AdapterPatternExample.Adapters
{
    public class PayPalAdapter : IPaymentProcessor
    {
        private PayPalGateway gateway;

        public PayPalAdapter(PayPalGateway gateway)
        {
            this.gateway = gateway;
        }

        public void ProcessPayment(double amount)
        {
            gateway.MakePayment(amount);
        }
    }
}