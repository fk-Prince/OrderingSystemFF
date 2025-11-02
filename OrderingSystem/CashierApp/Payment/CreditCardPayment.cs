using System;
using OrderingSystem.CashierApp.SessionData;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Payment
{
    public class CreditCardPayment : IPayment
    {

        private double amount;
        private readonly OrderServices orderServices;
        public string PaymentName => "Credit-Card";
        public CreditCardPayment(OrderServices orderServices)
        {
            this.orderServices = orderServices;
        }


        public double calculateFee(double amount)
        {
            return this.amount = amount;
        }



        public bool processPayment(OrderModel order, double cash)
        {
            if (SessionStaffData.StaffData == null)
                throw new ArgumentNullException("Staff information is required.");

            if (string.IsNullOrWhiteSpace(order.OrderId))
                throw new ArgumentException("Invalid order ID.");

            return orderServices.payOrder(order, SessionStaffData.StaffId, PaymentName);
        }

        public double getCash()
        {
            return 0;
        }
    }
}
