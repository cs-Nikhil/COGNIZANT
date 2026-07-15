namespace AdapterPatternExample.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }
}