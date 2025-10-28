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
        private MenuModel menu;
        private KioskMenuServices kioskMenuServices;
        public event EventHandler<List<MenuModel>> orderListEvent;
        private List<MenuModel> orderList;

        public MenuModel Menu => menu;

        public MenuCard(KioskMenuServices kioskMenuServices, MenuModel menu)
        {
            InitializeComponent();
            this.kioskMenuServices = kioskMenuServices;
            this.menu = menu;
            orderList = new List<MenuModel>();
            displayMenu();
            cardLayout();
        }

        private void cardLayout()
        {
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
            List<MenuModel> single = kioskMenuServices.getDetails(menu);
            if (single.Count == 1)
            {
                single[0].PurchaseQty++;
                orderListEvent?.Invoke(this, single);
                return;
            }
            PopupOption popup = new PopupOption(kioskMenuServices, menu, orderList);
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
            price.Text = menu.MenuPrice.ToString("C", new CultureInfo("en-PH"));
            image.Image = menu.MenuImage;
            description.Text = menu.MenuDescription;
            menuName.ForeColor = Color.Black;
            price.ForeColor = Color.Black;
            description.ForeColor = Color.Black;
        }
    }
}
