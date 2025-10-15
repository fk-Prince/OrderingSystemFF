using System;

namespace OrderingSystem.Model
{
    public class DiscountModel
    {
        public int DiscountId { get; protected set; }
        public DateTime DiscountAvailable { get; protected set; }
        public double DiscountRate { get; protected set; }
        public DiscountModel(int discountId, DateTime discountAvailable, double discountRate)
        {
            DiscountId = discountId;
            DiscountAvailable = discountAvailable;
            DiscountRate = discountRate;
        }
    }
}
