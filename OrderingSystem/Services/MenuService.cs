using System;
using System.Collections.Generic;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;

namespace OrderingSystem.Services
{
    public class MenuService
    {
        private IMenuRepository menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public bool saveMenu(MenuModel md, string type)
        {
            if (type.ToLower() == "regular")
                return menuRepository.createRegularMenu(md);
            else if (md is MenuPackageModel mp && type.ToLower() == "bundle")
                return menuRepository.createBundleMenu(mp);
            else
                throw new NotSupportedException("Not Supported.");
        }
        public bool updateMenu(MenuModel menu, string type)
        {
            if (menu is MenuPackageModel mp && type.ToLower() == "bundle")
                return menuRepository.updatePackageMenu(mp);
            else if (type.ToLower() == "regular")
                return menuRepository.updateRegularMenu(menu);
            else
                throw new NotSupportedException("Not Supported.");
        }
        public bool isMenuNameExist(string name)
        {
            return menuRepository.isMenuNameExist(name);
        }
        public List<MenuModel> getMenus()
        {
            return menuRepository.getMenu();
        }
        public List<MenuModel> getMenuDetail()
        {
            return menuRepository.getMenuDetail();
        }
        public List<MenuModel> getBundled(MenuModel menu)
        {
            return menuRepository.getBundled(menu);
        }
        public bool isMenuPackage(MenuModel menu)
        {
            return menuRepository.isMenuPackage(menu);
        }
        public double getBundlePrice(MenuModel menu)
        {
            return menuRepository.getBundlePrice(menu);
        }
        public bool newMenuVariant(int id, List<MenuModel> m)
        {
            return menuRepository.newMenuVariant(id, m);
        }

        public bool updateBundle2(int id, List<MenuModel> included)
        {
            return menuRepository.updateBundle2(id, included);
        }
    }
}
