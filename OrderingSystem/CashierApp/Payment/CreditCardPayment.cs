using System;
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



        public bool processPayment(StaffModel staff, string orderId, double cash)
        {
            if (staff == null)
                throw new ArgumentNullException("Staff information is required.");

            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentException("Invalid order ID.");

            return orderServices.payOrder(orderId, staff.StaffId, PaymentName);
        }
    }
}
