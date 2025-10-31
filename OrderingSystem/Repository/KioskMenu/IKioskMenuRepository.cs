using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface IKioskMenuRepository
    {
        List<MenuModel> getMenu();
        List<MenuModel> getDetails(MenuModel menu);
        bool getDetailCount(MenuModel menu);
        List<MenuModel> getDetailsByPackage(MenuModel menu);
        bool isMenuPackage(MenuModel menu);
        List<MenuModel> getFrequentlyOrderedTogether(MenuModel menu);
        int getMaxOrderRealTime(int menuDetailId, List<OrderItemModel> orderList);
        int getMaxOrderRealTime2(int menuDetailId, int menu_id, List<OrderItemModel> orderList);
        List<MenuModel> getIncludedMenu(MenuModel menu);
        double getNewPackagePrice(int menuid, List<MenuModel> selectedMenus);

        MenuModel getSelectedMenu(int menu_id, string flavorName, string sizeName);
    }
}
