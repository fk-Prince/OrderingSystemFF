using System;
using System.Drawing;
using System.Globalization;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Component
{
    public partial class OrderCard : Guna2Panel
    {

        public event EventHandler<OrderItemModel> AddQuantity;
        public event EventHandler<OrderItemModel> DeductQuantity;
        private OrderItemModel om;
        public OrderCard(OrderItemModel om)
        {
            InitializeComponent();
            this.om = om;
            refreshDetail();
        }

        private void addQuantity(object sender, System.EventArgs e)
        {
            AddQuantity?.Invoke(this, om);
        }

        private void deductQuantity(object sender, System.EventArgs e)
        {
            DeductQuantity?.Invoke(this, om);
        }

        public void refreshDetail()
        {
            image.Image = om.PurchaseMenu.MenuImage;
            name.Text = om.PurchaseMenu.MenuName;
            f2.Text = om.PurchaseMenu.FlavorName;
            s2.Text = om.PurchaseMenu.SizeName;

            BorderRadius = 10;
            BackColor = Color.Transparent;
            BorderColor = ColorTranslator.FromHtml("#DBEAFE");
            FillColor = Color.FromArgb(245, 245, 245);
            BorderThickness = 1;

            price.Text = om.PurchaseMenu.getPriceAfterVat().ToString("C", new CultureInfo("en-PH"));
            dPrice.Text = om.PurchaseMenu.getPriceAfterVat() != om.PurchaseMenu.getPriceAfterVatWithDiscount() ? om.PurchaseMenu.getPriceAfterVatWithDiscount().ToString("C", new CultureInfo("en-PH")) : "0.00";
            dPrice.Visible = om.PurchaseMenu.getPriceAfterVatWithDiscount() != om.PurchaseMenu.getPriceAfterVat();
            v1.Visible = om.PurchaseMenu.getPriceAfterVatWithDiscount() != om.PurchaseMenu.getPriceAfterVat();
            v2.Visible = om.PurchaseMenu.getPriceAfterVatWithDiscount() != om.PurchaseMenu.getPriceAfterVat();
            qty.Text = om.PurchaseQty.ToString();
            total.Text = om.getSubtotal().ToString("C", new CultureInfo("en-PH"));


            if (om.PurchaseMenu is MenuPackageModel)
            {

            }
            else if (om.PurchaseMenu.SizeName == om.PurchaseMenu.FlavorName)
            {
                s1.Visible = true;
                s2.Visible = true;
                s2.Text = om.PurchaseMenu.SizeName;
            }
            else
            {
                s1.Visible = true;
                s2.Visible = true;
                s2.Text = om.PurchaseMenu.SizeName;
                f1.Visible = true;
                f2.Visible = true;
                f2.Text = om.PurchaseMenu.SizeName;
            }
        }
    }
}
