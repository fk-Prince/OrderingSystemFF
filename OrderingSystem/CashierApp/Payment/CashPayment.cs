using System;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Payment
{
    public class CashPayment : IPayment
    {
        private double amount;
        private readonly OrderServices orderServices;
        public string PaymentName => "Cash";

        public CashPayment(OrderServices orderServices)
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

            if (cash <= 0)
                throw new InvalidPayment("Cash amount must be greater than zero.");

            if (amount > cash)
                throw new InsuffiecientAmount("The cash amount is insufficient to process the payment.");

            return orderServices.payOrder(orderId, staff.StaffId, PaymentName);
        }
    }
}
