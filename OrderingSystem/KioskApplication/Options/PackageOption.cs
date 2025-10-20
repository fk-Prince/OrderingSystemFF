using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Layouts;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.KioskApplication.Options
{
    public class PackageOption : IMenuOptions, ISelectedFrequentlyOrdered
    {

        private IKioskMenuRepository _menuRepository;
        private FlowLayoutPanel flowPanel;
        private FrequentlyOrderedOption frequentlyOrderedOption;
        private List<PackageLayout> _orderListPackage;

        private MenuModel menu;
        public PackageOption(IKioskMenuRepository _menuRepository, FlowLayoutPanel flowPanel)
        {
            this._menuRepository = _menuRepository;
            this.flowPanel = flowPanel;
            _orderListPackage = new List<PackageLayout>();
            frequentlyOrderedOption = new FrequentlyOrderedOption(_menuRepository, flowPanel);
        }
        public void displayMenuOptions(MenuModel menu)
        {
            try
            {
                this.menu = menu;
                List<MenuModel> menuList = _menuRepository.getIncludedMenu(menu);

                foreach (var item in menuList)
                {
                    var pakage = new PackageLayout(_menuRepository, item);
                    pakage.Margin = new Padding(20, 20, 0, 20);
                    flowPanel.Controls.Add(pakage);
                    _orderListPackage.Add(pakage);
                }

                frequentlyOrderedOption.displayFrequentlyOrdered(menu);
            }
            catch (Exception)
            {

                Console.WriteLine("Error on package option displayMenuOptions");
                throw;
            }
        }

        public List<MenuModel> getFrequentlyOrdered()
        {
            if (frequentlyOrderedOption != null)
                return frequentlyOrderedOption.getFrequentlyOrdered();
            return null;
        }

        public List<MenuModel> confirmOrder()
        {
            try
            {
                if (_orderListPackage.Any(pg => pg.SelectedMenuDetail == null || pg.SelectedMenuDetail.MaxOrder <= 0))
                {
                    throw new OutOfOrder("Currently this menu is unavailable.");
                }

                var includedMenu = _orderListPackage.Select(pg => pg.SelectedMenuDetail).ToList();
                double newPrice = _menuRepository.getNewPackagePrice(menu.MenuDetailId, includedMenu);

                var packageBundle = MenuPackageModel.Builder()
                    .WithMenuDetailId(menu.MenuDetailId)
                    .WithMenuName(menu.MenuName)
                    .WithPrice(newPrice)
                    .WithMenuImage(menu.MenuImage)
                    .WithMenuId(menu.MenuId)
                    .WithPackageIncluded(includedMenu)
                    .WithEstimatedTime(menu.EstimatedTime)
                    .Build();

                packageBundle.PurchaseQty++;
                return new List<MenuModel> { packageBundle };
            }
            catch (Exception)
            {
                Console.WriteLine("Error on package option confirm order");
                throw;
            }
        }
    }
}
