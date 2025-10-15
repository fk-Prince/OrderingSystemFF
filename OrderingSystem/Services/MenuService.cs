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

        public bool saveMenu(MenuModel md)
        {
            return menuRepository.createRegularMenu(md);
        }

        public bool updateMenu()
        {
            return false;
        }

        public bool saveBundleMenu()
        {
            return false;
        }

        public bool updateBundleMenu()
        {
            return false;
        }

        public bool isMenuNameExist(string name)
        {
            return menuRepository.isMenuNameExist(name);
        }

        public List<MenuModel> getMenus()
        {
            return menuRepository.getMenu();
        }
    }
}
