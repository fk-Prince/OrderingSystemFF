﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.KioskApplication.Interface;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.KioskApplication.Options
{
    public class RegularOption : IMenuOptions, ISelectedFrequentlyOrdered, IOrderNote
    {
        private readonly KioskMenuServices kioskMenuServices;
        private readonly FlowLayoutPanel flowPanel;
        private readonly FrequentlyOrderedOption frequentlyOrderedOption;

        //private Note n;
        private SizeLayout sc;
        private MenuModel menu;

        private MenuModel selectedFlavor;
        private MenuModel selectedSize;
        private string titleOption;
        private string subTitle;
        private List<MenuModel> menuDetails;

        public string getNote { get; set; } = "";

        public RegularOption(KioskMenuServices kioskMenuServices, FlowLayoutPanel flowPanel)
        {
            this.kioskMenuServices = kioskMenuServices;
            this.flowPanel = flowPanel;
            frequentlyOrderedOption = new FrequentlyOrderedOption(kioskMenuServices, flowPanel);
        }
        public void displayMenuOptions(MenuModel menu)
        {
            try
            {
                this.menu = menu;
                menuDetails = kioskMenuServices.getDetails(menu);
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
            string t = "Select Your Menu.";
            titleOption = "Option A";
            subTitle = "Select Flavor of your choice.";

            var x = menuDetails
                .GroupBy(ex => ex.FlavorName)
                .Select(group => group.First())
                .ToList();


            FlavorLayout fl = new FlavorLayout(x);
            fl.Margin = new Padding(20, 30, 0, 0);
            fl.FlavorSelected += (s, e) => flavorSelected(s, e);
            fl.setTitle(titleOption, menu.MenuName);
            fl.setSubTitle(subTitle);
            fl.defaultSelection();
            if (x.Count <= 1 && getSizeCount(menuDetails, menu.MenuId, x[0].FlavorName) > 1)
                filterSizeByFlavor(menuDetails, menu.MenuId, "");
            else
            {
                flowPanel.Controls.Add(fl);
                fl.setSubTitle(t);
            }
            titleOption = "Option B";
            selectedFlavor = x[0];


        }
        private void filterSizeByFlavor(List<MenuModel> menuDetails, int menuid, string flavor)
        {
            List<MenuModel> l = string.IsNullOrWhiteSpace(flavor) ? menuDetails.FindAll(x => menuid == x.MenuId) : menuDetails.FindAll(x => menuid == x.MenuId && x.FlavorName == flavor);
            displaySize(l);
        }
        public int getSizeCount(List<MenuModel> menuDetails, int menuid, string flavor)
        {
            return string.IsNullOrWhiteSpace(flavor) ? menuDetails.FindAll(x => menuid == x.MenuId).Count : menuDetails.FindAll(x => menuid == x.MenuId && x.FlavorName == flavor).Count;
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
        public List<OrderItemModel> getFrequentlyOrdered()
        {
            return frequentlyOrderedOption?.getFrequentlyOrdered();
        }
        public List<OrderItemModel> confirmOrder()
        {
            if (selectedFlavor == null && selectedSize == null)
                throw new NoSelectedMenu("No Selected Menu.");


            var selectedMenu = menuDetails.FirstOrDefault(m =>
                     m.FlavorName.Equals(selectedFlavor.FlavorName, StringComparison.OrdinalIgnoreCase) &&
                     m.SizeName.Equals(selectedSize.SizeName, StringComparison.OrdinalIgnoreCase));


            if (selectedMenu.MaxOrder <= 0)
                throw new OutOfOrder("This menu is out of order.");

            var purchaseMenu = getMenuPurchase(selectedMenu);

            return new List<OrderItemModel> { purchaseMenu };

        }
        public OrderItemModel getMenuPurchase(MenuModel selectedMenu)
        {
            var m = MenuModel.Builder()
                         .WithMenuName(selectedMenu.MenuName)
                         .WithMenuId(selectedMenu.MenuId)
                         .WithMenuDetailId(selectedMenu.MenuDetailId)
                         .WithEstimatedTime(selectedMenu.EstimatedTime)
                         .WithSizeName(selectedMenu.SizeName)
                         //.WithPurchaseNote(n?.txt.Text.Trim())
                         .WithFlavorName(selectedMenu.FlavorName)
                         .WithMenuImage(selectedMenu.MenuImage)
                         .WithPrice(selectedMenu.MenuPrice)
                         .WithDiscount(selectedMenu.Discount)
                         .Build();

            OrderItemModel om = OrderItemModel.Builder()
                         .WithPurchaseMenu(m)
                         .WithPurchaseQty(1)
                         .Build();
            return om;
        }
        public void displayOrderNotice()
        {
            //n = new Note();
            //n.Margin = new Padding(20, 0, 0, 30);
            //flowPanel.Controls.Add(n);
        }
    }
}
