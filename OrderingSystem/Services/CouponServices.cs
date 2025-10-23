

using System;
using System.Collections.Generic;
using OrderingSystem.Exceptions;
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
                    throw new InvalidInput("Invalid rate.");
                }

                if (dRate < 0 || dRate > 100)
                {
                    throw new InvalidInput("Rate must be greater than 0 and less than 100.");
                }

                dRate = dRate / 100;

                if (dateTime <= DateTime.Now)
                {
                    throw new InvalidInput("Date should be greater today");

                }

                if (!int.TryParse(numberofTimes, out int times) || times <= 0)
                {
                    throw new InvalidInput("Number of times must be a positive whole number.");
                }
                CouponModel cc = new CouponModel(dRate, dateTime, description, times);
                return couponRepository.generateCoupon(cc);
            }
            catch (InvalidInput e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error.");
            }
        }


        public List<CouponModel> getCoupons()
        {
            return couponRepository.getAllCoupon();
        }
    }
}
