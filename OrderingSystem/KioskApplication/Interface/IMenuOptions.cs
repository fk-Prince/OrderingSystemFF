using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Services
{
    public interface IMenuOptions
    {
        void displayMenuOptions(MenuModel menu);
        List<OrderItemModel> confirmOrder();
    }
}
