namespace OrderingSystem.CashierApp.Payment
{
    public interface IPayment
    {

        string PaymentName { get; }
        double calculateFee(double amount);
        bool processPayment(string orderId, double cash);
    }
}
