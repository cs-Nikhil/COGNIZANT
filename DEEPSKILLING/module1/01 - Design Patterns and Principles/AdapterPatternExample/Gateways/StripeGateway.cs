using System;

namespace AdapterPatternExample.Gateways
{
    public class StripeGateway
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Stripe Payment Processed: {amount}");
        }
    }
}