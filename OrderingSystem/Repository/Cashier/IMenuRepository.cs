using System.Collections.Generic;
using OrderingSystem.Model;

namespace OrderingSystem.Repo.CashierMenuRepository
{
    public interface IMenuRepository
    {
        bool isMenuNameExist(string name);
        bool updateRegularMenu(MenuModel update);
        bool updatePackageMenu(MenuPackageModel update);
        bool isMenuPackage(MenuModel m);
        bool createRegularMenu(MenuModel md);
        bool createBundleMenu(MenuPackageModel md);
        bool newMenuVariant(int menuId, List<MenuModel> m);
        List<string> getFlavor();
        List<MenuModel> getMenu();
        List<MenuModel> getBundled(MenuModel menu);
        List<MenuModel> getMenuDetail();
        List<string> getSize();
        double getBundlePrice(MenuModel menu);

        bool updateBundle2(int id, List<MenuModel> included);
    }
}
