using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Options
{
    public interface ISelectedFrequentlyOrdered
    {

        List<MenuModel> getFrequentlyOrdered();
    }
}
