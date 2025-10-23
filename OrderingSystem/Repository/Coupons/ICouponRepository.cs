using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface ICouponRepository
    {

        CouponModel getCoupon(string code);
        List<CouponModel> getAllCoupon();
        bool generateCoupon(CouponModel co);
    }
}
