﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.KioskApplication.Layouts
{
    public partial class PackageLayout : Guna2Panel
    {
        private string titleOption;
        private string subTitle;
        private SizeLayout sc;
        private MenuModel selectedFlavor;
        private MenuModel selectedSize;

        private MenuModel selectedMenu;
        public MenuModel SelectedMenuDetail => selectedMenu;

        private readonly MenuModel menuDetail;
        private readonly List<MenuModel> menuDetails;
        public PackageLayout(KioskMenuServices kioskMenuServices, MenuModel menuDetail)
        {
            InitializeComponent();
            this.menuDetail = menuDetail;
            try
            {
                menuDetails = kioskMenuServices.getDetailsByPackage(menuDetail);
                cardLayout();
                displayFlavor(menuDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cardLayout()
        {
            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;
        }
        private void displayFlavor(MenuModel menuDetail)
        {

            titleOption = "Option A";
            subTitle = $"Select Flavor of your choice.";
            try
            {
                var x = menuDetails
                   .GroupBy(ex => ex.FlavorName)
                   .Select(group => group.First())
                   .ToList();


                if (menuDetail is MenuPackageModel mp)
                {
                    if (mp.isFixed)
                    {
                        x = menuDetails.Take(1).ToList();
                    }
                }

                FlavorLayout fl = new FlavorLayout(x);
                fl.Margin = new Padding(0);
                fl.BorderThickness = 0;
                fl.BorderRadius = 0;
                fl.FlavorSelected += flavorSelected;
                fl.setTitle(titleOption, menuDetail.MenuName);
                fl.setSubTitle(subTitle);
                fl.defaultSelection();
                flowPanel.Controls.Add(fl);
                adjustHeight();
                titleOption = "Option B";
                selectedFlavor = x[0];
                filterSizeByFlavor(menuDetails, menuDetail.MenuId, menuDetail.FlavorName);
            }
            catch (Exception)
            {
                Console.WriteLine("Error on PackageLayout displayFlavor");
                throw;
            }
        }
        private void filterSizeByFlavor(List<MenuModel> menuDetails, int menuid, string flavor)
        {
            List<MenuModel> l = string.IsNullOrWhiteSpace(flavor) ? menuDetails.FindAll(x => menuid == x.MenuId) : menuDetails.FindAll(x => menuid == x.MenuId && x.FlavorName == flavor);
            displaySize(l);
        }
        private void flavorSelected(object sender, MenuModel e)
        {
            selectedFlavor = e;

            if (sc != null)
            {
                if (flowPanel.Controls.Contains(sc))
                {
                    flowPanel.Controls.Remove(sc);
                }
                sc.Dispose();
                sc = null;
                resetHeight();
            }
            if (e != null)
                filterSizeByFlavor(menuDetails, menuDetail.MenuId, menuDetail.FlavorName);
        }
        private void displaySize(List<MenuModel> menuList)
        {

            if (sc != null)
            {
                if (flowPanel.Controls.Contains(sc))
                {
                    flowPanel.Controls.Remove(sc);
                }
                sc.Dispose();
                sc = null;
            }
            var x = menuList
                  .GroupBy(ex => ex.SizeName)
                  .Select(group => group.First())
                  .ToList();

            if (menuDetail is MenuPackageModel mp)
            {
                if (mp.isFixed)
                {
                    x = menuDetails.Take(1).ToList();
                }
            }


            subTitle = $"Select Size of your choice.";
            sc = new SizeLayout(selectedFlavor, x);
            sc.Margin = new Padding(0);
            sc.BorderThickness = 0;
            sc.BorderRadius = 0;
            sc.setTitleOption(titleOption, menuList[0].MenuName);
            sc.setSubTitle(subTitle);
            sc.SizeSelected += (s, e) =>
            {
                selectedSize = e;
                string flavorName = selectedFlavor?.FlavorName ?? "";
                string sizeName = selectedSize?.SizeName ?? "";
                if (flavorName == "" && sizeName == "") return;
                getSelectedMenu();
            };
            flowPanel.Controls.Add(sc);
            sc.defaultSelection();
            adjustHeight();
            selectedSize = x[0];
            getSelectedMenu();
        }
        private void getSelectedMenu()
        {
            string flavorName = selectedFlavor?.FlavorName ?? "";
            string sizeName = selectedSize?.SizeName ?? "";
            selectedMenu = menuDetails.Find(e => (e.MenuDetailId == selectedFlavor.MenuDetailId || e.MenuDetailId == selectedSize.MenuDetailId) && e.FlavorName == flavorName && e.SizeName == sizeName);
        }
        private void adjustHeight()
        {
            int totalHeight = 0;
            foreach (Control control in flowPanel.Controls)
            {
                totalHeight += control.Height + control.Margin.Top;
            }

            flowPanel.Height = totalHeight;
            Height = totalHeight + 10;

            PerformLayout();
            Parent?.PerformLayout();
        }
        private void resetHeight()
        {
            int heigt = 0;
            foreach (Control c in flowPanel.Controls)
            {
                if (c is FlavorLayout)
                {
                    heigt += c.Height + c.Margin.Top;
                }
            }

            flowPanel.Height = heigt;
            Height = heigt + 10;

            PerformLayout();
            Parent?.PerformLayout();
        }
    }
}
