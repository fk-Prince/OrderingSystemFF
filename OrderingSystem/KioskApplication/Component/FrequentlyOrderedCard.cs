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
        private MenuModel selectedMenu;
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
                    checkedMenu.Invoke(this, selectedMenu);
                }
                else
                {
                    BorderColor = Color.DarkGray;
                    BorderThickness = 1;
                    unCheckedMenu.Invoke(this, selectedMenu);
                    selectedMenu = null;
                }
            };
        }

        private void displayMenu()
        {
            menuName.Text = menu.MenuName;
            detail.Text = menu.SizeName;
            price.Text = "₱       + " + menu.GetDiscountedPrice().ToString("N2");
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
            selectedMenu = menu;
        }

        private void price_Click(object sender, EventArgs e)
        {

        }
    }
}
