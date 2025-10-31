using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Interface
{
    public interface ICalculateOrder
    {
        double calculateSubtotal();
        double calculateCoupon(CouponModel coupon);
        double calculateTotalAmount();
    }
}
