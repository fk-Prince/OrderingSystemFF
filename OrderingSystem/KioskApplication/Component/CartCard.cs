using System;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
namespace OrderingSystem.KioskApplication.Components
{
    public partial class CartCard : Guna2Panel
    {
        private MenuModel menu;
        public event EventHandler<MenuModel> addQuantityEvent;
        public event EventHandler<MenuModel> deductQuantityEvent;
        public CartCard(MenuModel menu)
        {
            InitializeComponent();
            this.menu = menu;
            displayPurchasedMenu();
            cardLayout();
        }

        private void cardLayout()
        {
            BorderRadius = 5;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(255, 255, 255);
            BackColor = Color.Transparent;
        }

        public void displayPurchasedMenu()
        {

            menuName.Text = menu.MenuName;
            price.Text = menu.GetDiscountedPrice().ToString("N2");

            string text = "";

            if (menu is MenuPackageModel p) text = "Package";
            else if (menu.SizeName == menu.FlavorName) text = "Regular";
            else text = "Flavor: " + menu.FlavorName + "   -   Size:" + menu.SizeName;
            image.Image = menu.MenuImage;
            detail.Text = text;
            qty.Text = menu.PurchaseQty.ToString();
            bb.Text = qty.Text;
            total.Text = (menu.GetDiscountedPrice() * menu.PurchaseQty).ToString("N2");
        }

        private void addQuantity(object sender, System.EventArgs e)
        {
            addQuantityEvent.Invoke(this, menu);
            displayPurchasedMenu();
        }

        private void deductQuantity(object sender, System.EventArgs e)
        {
            deductQuantityEvent.Invoke(this, menu);
            displayPurchasedMenu();
        }



        private void CartCard_Load(object sender, EventArgs e)
        {

        }
    }
}
