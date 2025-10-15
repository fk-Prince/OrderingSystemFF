using System;

namespace OrderingSystem.Model
{
    public class CouponModel
    {
        private string couponCode;
        private string status;
        private double couponRate;
        private DateTime expiryDate;

        public CouponModel(string couponCode, string status, double couponRate, DateTime expiryDate)
        {
            this.couponCode = couponCode;
            this.status = status;
            this.couponRate = couponRate;
            this.expiryDate = expiryDate;
        }

        public string CouponCode { get => couponCode; set => couponCode = value; }
        public string Status { get => status; set => status = value; }
        public double CouponRate { get => couponRate; set => couponRate = value; }
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }
    }
}
