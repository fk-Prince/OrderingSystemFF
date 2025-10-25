namespace OrderingSystem.CashierApp.Payment
{
    public interface IPaymentFactoryType
    {
        IPayment paymentType(string type);
    }
}
