using System;

namespace OrderingSystem.Model
{
    public class DiscountModel
    {
        public int DiscountId { get; protected set; }
        public double Rate { get; protected set; }
        public DateTime UntilDate { get; protected set; }
        public string DisplayText { get; set; }
        public static DiscountBuilder Builder() => new DiscountBuilder();

        public interface IDiscountBuilder
        {
            DiscountBuilder WithDiscountId(int discountId);
            DiscountBuilder WithRate(double rate);
            DiscountBuilder WithUntilDate(DateTime untilDate);
        }

        public class DiscountBuilder : IDiscountBuilder
        {
            private readonly DiscountModel discountModel;
            public DiscountBuilder()
            {
                discountModel = new DiscountModel();
            }
            public DiscountBuilder WithDiscountId(int discountId)
            {
                discountModel.DiscountId = discountId;
                return this;
            }
            public DiscountBuilder WithRate(double rate)
            {
                discountModel.Rate = rate;
                return this;
            }
            public DiscountBuilder WithUntilDate(DateTime untilDate)
            {
                discountModel.UntilDate = untilDate;
                return this;
            }
            public DiscountModel Build()
            {
                return discountModel;
            }
        }
    }
}
