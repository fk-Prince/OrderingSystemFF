﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Interface;
using OrderingSystem.KioskApplication.Options;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.KioskApplication
{
    public partial class PopupOption : Form
    {
        public MenuModel menu { get; }
        private KioskMenuServices kioskMenuServices;
        public event EventHandler<List<OrderItemModel>> orderListEvent;
        private IMenuOptions menuOptions;
        public PopupOption(KioskMenuServices kioskMenuServices, MenuModel menu)
        {
            InitializeComponent();
            this.kioskMenuServices = kioskMenuServices;
            this.menu = menu;
            displayDetails(menu);
            diisplayOptions();
        }


        public void diisplayOptions()
        {
            try
            {
                if (kioskMenuServices.isMenuPackage(menu))
                {
                    menuOptions = new PackageOption(kioskMenuServices, flowPanel);
                }
                else
                {
                    menuOptions = new RegularOption(kioskMenuServices, flowPanel);
                }
                if (menuOptions is IOutOfOrder e)
                {
                    e.outOfOrder += (ses, ese) =>
                    {
                        bb.Enabled = false;
                    };
                }
                menuOptions.displayMenuOptions(menu);


                if (menuOptions is IOrderNote i)
                    i.displayOrderNotice();

            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void displayDetails(MenuModel menu)
        {
            image.Image = menu.MenuImage;
            menuName.Text = menu.MenuName;
            description.Text = menu.MenuDescription;
        }
        private void addToOrder(object sender, System.EventArgs e)
        {
            List<OrderItemModel> order = new List<OrderItemModel>();
            try
            {
                if (menuOptions != null)
                {
                    if (menuOptions is ISelectedFrequentlyOrdered freqOrdered)
                    {

                        var frequentlyOrdered = freqOrdered.getFrequentlyOrdered();
                        if (frequentlyOrdered != null)
                            order.AddRange(frequentlyOrdered);
                    }

                    if (menuOptions is IOrderNote iNo)
                    {
                        string ino = iNo.getNote;
                    }

                    var orders = menuOptions.confirmOrder();
                    if (orders == null || orders.Count == 0)
                        return;


                    order.AddRange(orders);
                    orderListEvent?.Invoke(this, order);
                    DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex) when (ex is OutOfOrder || ex is NoSelectedMenu)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void close(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

    }
}
