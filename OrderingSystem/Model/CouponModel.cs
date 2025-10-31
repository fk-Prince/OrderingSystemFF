using System;

namespace OrderingSystem.Model
{
    public class CouponModel
    {
        private string couponCode;
        private string status;
        private string description;
        private double couponRate;
        private int numberOfTimes;
        private DateTime expiryDate;
        public CouponModel(double couponRate)
        {
            this.couponRate = couponRate;

        }
        public CouponModel(string couponCode, string status, double couponRate, DateTime expiryDate, string description)
        {
            this.couponCode = couponCode;
            this.status = status;
            this.couponRate = couponRate;
            this.expiryDate = expiryDate;
            this.description = description;
        }
        public CouponModel(double couponRate, DateTime expiryDate, string description, int numberOfTimes)
        {
            this.couponRate = couponRate;
            this.expiryDate = expiryDate;
            this.description = description;
            this.numberOfTimes = numberOfTimes;
        }

        public string CouponCode { get => couponCode; set => couponCode = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public double CouponRate { get => couponRate; set => couponRate = value; }
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public int NumberOfTimes { get => numberOfTimes; set => numberOfTimes = value; }
    }
}
