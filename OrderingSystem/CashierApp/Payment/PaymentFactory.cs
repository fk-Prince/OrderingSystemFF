using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Services;

namespace OrderingSystem.CashierApp.Payment
{
    public class PaymentFactory : IPaymentFactoryType
    {
        private OrderServices orderServices;
        public PaymentFactory(OrderServices orderServices)
        {
            this.orderServices = orderServices;
        }
        public IPayment paymentType(string type)
        {
            if (type.ToLower() == "cash")
                return new CashPayment(orderServices);
            else if (type.ToLower() == "creditcard" || type.ToLower() == "credit-card")
                return new CreditCardPayment(orderServices);
            else
                throw new InvalidPayment("Payment Not Supported Yet.");
        }
    }
}
