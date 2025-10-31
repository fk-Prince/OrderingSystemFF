using System;
using System.Collections.Generic;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.Services
{
    public class KioskMenuServices
    {
        private IKioskMenuRepository menuRepository;
        public KioskMenuServices(IKioskMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public List<MenuModel> getMenu()
        {
            return menuRepository.getMenu();
        }

        public int getMaxOrderRealTime(int menuDetailId, List<OrderItemModel> orderList)
        {
            return menuRepository.getMaxOrderRealTime(menuDetailId, orderList);
        }

        public List<MenuModel> getDetails(MenuModel menu)
        {
            return menuRepository.getDetails(menu);
        }

        public bool isMenuPackage(MenuModel menu)
        {
            return menuRepository.isMenuPackage(menu);
        }

        public List<MenuModel> getFrequentlyOrderedTogether(MenuModel menus)
        {
            return menuRepository.getFrequentlyOrderedTogether(menus);
        }

        public List<MenuModel> getIncludedMenu(MenuModel menu)
        {
            return menuRepository.getIncludedMenu(menu);
        }

        public double getNewPackagePrice(int menuDetailId, List<MenuModel> includedMenu)
        {
            return menuRepository.getNewPackagePrice(menuDetailId, includedMenu);
        }

        public List<MenuModel> getDetailsByPackage(MenuModel menuDetail)
        {
            return menuRepository.getDetailsByPackage(menuDetail);
        }

        internal List<MenuModel> getMenuDetail()
        {
            throw new NotImplementedException();
        }
    }
}
