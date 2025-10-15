namespace OrderingSystem.Repository
{
    public interface ICouponRepository
    {
        Model.CouponModel getCoupon(string code);
    }
}
