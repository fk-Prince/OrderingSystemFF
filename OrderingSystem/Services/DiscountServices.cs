﻿using System;
using System.Collections.Generic;
using System.Linq;
using OrderingSystem.Exceptions;
using OrderingSystem.Model;
using OrderingSystem.Repository.Discount;

namespace OrderingSystem.Services
{
    public class DiscountServices
    {
        private readonly IDiscountRepository discountRepository;
        public DiscountServices(IDiscountRepository discountRepository)
        {
            this.discountRepository = discountRepository;
        }

        public List<DiscountModel> GetDiscount()
        {
            return discountRepository.GetDiscount();
        }

        public List<DiscountModel> GetDiscountAvailable()
        {
            List<DiscountModel> d = GetDiscount();
            return d.Where(dx => dx.UntilDate > DateTime.Now).ToList();
        }

        public bool AddDiscount(string rate, DateTime date)
        {
            if (!double.TryParse(rate, out var d))
                throw new InvalidInput("Invalid Discount Rate, rate should be number");

            if (d > 100)
                throw new InvalidInput("Invalid Discount Rate, rate should cannot exceed 100");

            if (d < 1)
                throw new InvalidInput("Invalid Discount Rate, rate should cannot less than 1");

            if (DateTime.Now > date)
                throw new InvalidInput("Invalid Date. Date is past");

            d /= 100;

            return discountRepository.SaveDate(d, date);
        }
    }
}
