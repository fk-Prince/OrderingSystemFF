

using System;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.Coupon;

namespace OrderingSystem.Services
{
    public class CouponServices
    {
        private ICouponRepository couponRepository;
        public CouponServices()
        {
            couponRepository = new CouponRepository();
        }
        public bool saveAction(string rate, DateTime dateTime, string numberofTimes, string description)
        {
            try
            {

                if (!double.TryParse(rate, out double dRate))
                {
                    MessageBox.Show("Invalid rate.");
                    return false;
                }

                if (dRate < 0 || dRate > 100)
                {
                    MessageBox.Show("Rate must be greater than 0 and less than 100.");
                    return false;
                }

                dRate = dRate / 100;

                if (dateTime <= DateTime.Now)
                {
                    MessageBox.Show("Date should be greater today");
                    return false;
                }

                if (!int.TryParse(numberofTimes, out int times) || times <= 0)
                {
                    MessageBox.Show("Number of times must be a positive whole number.");
                    return false;
                }

                CouponModel cc = new CouponModel(dRate, dateTime, description, times);

                bool suc = couponRepository.generateCoupon(cc);

                return suc;
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Service Error");
            }
            return false;
        }
    }
}
