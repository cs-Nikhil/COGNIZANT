using System;

namespace AdapterPatternExample.Gateways
{
    public class PayPalGateway
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"PayPal Payment Processed: {amount}");
        }
    }
}