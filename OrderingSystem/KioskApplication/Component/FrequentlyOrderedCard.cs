using System;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
namespace OrderingSystem.KioskApplication.Components
{
    public partial class FrequentlyOrderedCard : Guna2Panel
    {
        private MenuModel menu;
        public event EventHandler<MenuModel> checkedMenu;
        public event EventHandler<MenuModel> unCheckedMenu;

        public FrequentlyOrderedCard(MenuModel menu)
        {
            InitializeComponent();
            this.menu = menu;
            cardLayout();
            displayMenu();
            cardChecked();
        }

        private void cardChecked()
        {
            checkBox.Checked = false;
            checkBox.CheckedChanged += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    BorderColor = Color.FromArgb(94, 148, 255);
                    BorderThickness = 2;
                    menu.PurchaseQty++;
                    checkedMenu.Invoke(this, menu);
                }
                else
                {
                    BorderColor = Color.DarkGray;
                    BorderThickness = 1;
                    unCheckedMenu.Invoke(this, menu);
                    menu = null;
                }
            };
        }

        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            detail.Text = menu.SizeName;
            price.Text = "₱       + " + menu.getPrice().ToString("N2");
            image.Image = menu.MenuImage;
        }

        private void cardLayout()
        {
            BorderRadius = 5;
            BorderColor = Color.DarkGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {

        }

        private void price_Click(object sender, EventArgs e)
        {

        }
    }
}
