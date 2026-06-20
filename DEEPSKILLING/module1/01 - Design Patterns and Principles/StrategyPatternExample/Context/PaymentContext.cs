using StrategyPatternExample.Strategies;

namespace StrategyPatternExample.Context
{
    public class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(double amount)
        {
            paymentStrategy.Pay(amount);
        }
    }
}