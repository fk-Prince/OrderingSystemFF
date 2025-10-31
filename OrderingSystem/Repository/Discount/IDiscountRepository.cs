using System;
using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository.Discount
{
    public interface IDiscountRepository
    {

        List<DiscountModel> GetDiscount();
        bool SaveDate(double rate, DateTime date);
    }
}
