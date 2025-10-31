using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.KioskApplication.Cards
{
    public partial class MenuCard : Guna2Panel

    {
        private readonly MenuModel menu;
        private readonly KioskMenuServices kioskMenuServices;
        public event EventHandler<List<OrderItemModel>> orderListEvent;

        public MenuCard(KioskMenuServices kioskMenuServices, MenuModel menu)
        {
            InitializeComponent();
            this.kioskMenuServices = kioskMenuServices;
            this.menu = menu;
            displayMenu();
            cardLayout();
        }

        public void outOfOrder(bool b)
        {
            ooo.Visible = b;
        }
        private void cardLayout()
        {
            dPrice.Text = menu.getPriceAfterVat() != menu.getPriceAfterVatWithDiscount() ? menu.getPriceAfterVatWithDiscount().ToString("C", new CultureInfo("en-PH")) : "0.00";
            dPrice.Visible = menu.getPriceAfterVatWithDiscount() != menu.getPriceAfterVat();
            v1.Visible = menu.getPriceAfterVatWithDiscount() != menu.getPriceAfterVat();
            v2.Visible = menu.getPriceAfterVatWithDiscount() != menu.getPriceAfterVat();

            ooo.Visible = !(menu.MaxOrder <= 0);
            BorderRadius = 8;
            BorderThickness = 1;
            BorderColor = Color.FromArgb(34, 34, 34);
            FillColor = Color.White;
            handleClicked(this);
            hoverEffects(this);
        }
        private void menuClicked(object sender, EventArgs b)
        {
            PopupOption popup = new PopupOption(kioskMenuServices, menu);
            popup.orderListEvent += (s, e) => orderListEvent?.Invoke(this, e);
            DialogResult res = popup.ShowDialog(this);
            if (res == DialogResult.OK)
                popup.Hide();
        }
        private void handleClicked(Control c)
        {
            c.Click += menuClicked;
            foreach (Control cc in c.Controls)
                handleClicked(cc);
        }
        private void hoverEffects(Control c)
        {
            c.MouseEnter += (s, e) => { BorderColor = Color.FromArgb(94, 148, 255); BorderThickness = 2; };
            c.MouseLeave += (s, e) => { BorderColor = Color.FromArgb(34, 34, 34); BorderThickness = 1; };
            c.Cursor = Cursors.Hand;
            foreach (Control cc in c.Controls)
                hoverEffects(cc);
        }
        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            price.Text = menu.getPriceAfterVat().ToString("C", new CultureInfo("en-PH"));
            image.Image = menu.MenuImage;
            description.Text = menu.MenuDescription;
            menuName.ForeColor = Color.Black;
            price.ForeColor = Color.Black;
            description.ForeColor = Color.Black;
        }


    }
}
