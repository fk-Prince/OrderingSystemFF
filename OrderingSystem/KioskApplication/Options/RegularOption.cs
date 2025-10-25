using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.KioskApplication.Options
{
    public class RegularOption : IMenuOptions, ISelectedFrequentlyOrdered
    {
        private IKioskMenuRepository _menuRepository;
        private FlowLayoutPanel flowPanel;
        private SizeLayout sc;
        private MenuModel menu;
        private FrequentlyOrderedOption frequentlyOrderedOption;

        private MenuModel selectedFlavor;
        private MenuModel selectedSize;
        private string titleOption;
        private string subTitle;


        private List<MenuModel> menuDetails;
        public event EventHandler<MenuModel> OneMenu;

        public RegularOption(IKioskMenuRepository _menuRepository, FlowLayoutPanel flowPanel)
        {
            this._menuRepository = _menuRepository;
            this.flowPanel = flowPanel;

            frequentlyOrderedOption = new FrequentlyOrderedOption(_menuRepository, flowPanel);
        }

        public void displayMenuOptions(MenuModel menu)
        {
            try
            {
                this.menu = menu;
                menuDetails = _menuRepository.getDetails(menu);
                displayFlavor(menuDetails);
                frequentlyOrderedOption.displayFrequentlyOrdered(menu);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void displayFlavor(List<MenuModel> menuDetails)
        {
            titleOption = "Option A";
            subTitle = "Select Flavor of your choice.";

            var x = menuDetails
                .GroupBy(ex => ex.FlavorName)
                .Select(group => group.First())
                .ToList();

            if (x.Count > 1)
            {
                FlavorLayout fl = new FlavorLayout(x);
                fl.Margin = new Padding(20, 30, 0, 0);
                fl.FlavorSelected += (s, e) => flavorSelected(s, e);
                fl.setTitle(titleOption, menu.MenuName);
                fl.setSubTitle(subTitle);
                fl.defaultSelection();
                flowPanel.Controls.Add(fl);
                titleOption = "Option B";
            }
            else
            {
                selectedFlavor = x[0];
                filterSizeByFlavor(menuDetails, menu.MenuId, "");
            }
        }
        private void filterSizeByFlavor(List<MenuModel> menuDetails, int menuid, string flavor)
        {
            List<MenuModel> l = string.IsNullOrWhiteSpace(flavor) ? menuDetails.FindAll(x => menuid == x.MenuId) : menuDetails.FindAll(x => menuid == x.MenuId && x.FlavorName == flavor);
            displaySize(l);
        }
        private void flavorSelected(object sender, MenuModel e)
        {
            if (e != null)
            {
                filterSizeByFlavor(menuDetails, e.MenuId, e.FlavorName);
                selectedFlavor = e;
            }
        }
        private void displaySize(List<MenuModel> menuDetails)
        {
            if (sc != null) flowPanel.Controls.Remove(sc);

            var x = menuDetails
               .GroupBy(ex => ex.SizeName)
               .Select(group => group.First())
               .ToList();

            if (x.Count > 1)
            {
                subTitle = "Select Size of your choice";
                sc = new SizeLayout(selectedFlavor, menuDetails);
                sc.Margin = new Padding(20, 30, 0, 0);
                sc.SizeSelected += (s, e) => selectedSize = e;
                sc.setTitleOption(titleOption, x[0].MenuName);
                sc.setSubTitle(subTitle);
                sc.defaultSelection();
                flowPanel.Controls.Add(sc);
            }
            else
            {
                selectedSize = x[0];
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

            if (selectedFlavor == null && selectedSize == null)
            {
                throw new NoSelectedMenu("No Selected Menu.");
            }
            var selectedMenu = menuDetails.FirstOrDefault(m => m.FlavorName == selectedFlavor.FlavorName && m.SizeName == selectedFlavor.SizeName);
            if (selectedMenu.MaxOrder <= 0)
            {
                throw new OutOfOrder("This menu is out of order.");
            }

            var purchaseMenu = getMenuPurchase(selectedMenu);


            return new List<MenuModel> { purchaseMenu };

        }

        public MenuModel getMenuPurchase(MenuModel selectedMenu)
        {
            var m = MenuModel.Builder()
                         .WithMenuName(selectedMenu.MenuName)
                         .WithMenuId(selectedMenu.MenuId)
                         .WithMenuDetailId(selectedMenu.MenuDetailId)
                         .WithEstimatedTime(selectedMenu.EstimatedTime)
                         .WithSizeName(selectedMenu.SizeName)
                         .WithFlavorName(selectedMenu.FlavorName)
                         .WithMenuImage(selectedMenu.MenuImage)
                         .WithPrice(selectedMenu.getPrice())
                         .Build();
            m.PurchaseQty += 1;
            return m;
        }
    }
}
