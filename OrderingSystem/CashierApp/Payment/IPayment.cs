using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Payment
{
    public interface IPayment
    {

        string PaymentName { get; }
        double calculateFee(double amount);
        bool processPayment(OrderModel order, double cash);

        double getCash();
    }
}
