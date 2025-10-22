using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface ICouponRepository
    {

        CouponModel getCoupon(string code);
        bool generateCoupon(CouponModel co);
    }
}
