using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms;
using OrderingSystem.KioskApplication;
using OrderingSystem.KioskApplication.Cards;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.Coupon;
using OrderingSystem.Repository.Menus;
using OrderingSystem.Repository.Order;

namespace OrderingSystem
{
    public partial class KioskLayout : Form
    {

        private IKioskMenuRepository menuRepository;
        private ICategoryRepository categoryRepository;
        private Guna2Button lastActiveButton;
        private CartServices cartServices;
        private CouponModel couponSelected;
        private bool isShowing = false;
        private List<MenuModel> orderList;
        private int x;
        public KioskLayout()
        {
            InitializeComponent();
            categoryRepository = new CategoryRepository();
            orderList = new List<MenuModel>();
            menuRepository = new KioskMenuRepository(orderList);
            cartServices = new CartServices(menuRepository, flowCart, orderList);
            cartServices.quantityChanged += displayTotal;
        }

        private void KioskLayout_Load(object sender, System.EventArgs e)
        {
            fetchDataMenu();
            fetchDataCategory();
        }
        private void fetchDataMenu()
        {
            try
            {
                List<MenuModel> menuList = menuRepository.getMenu();
                displayMenu(menuList);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
        private void fetchDataCategory()
        {
            try
            {
                List<CategoryModel> catList = categoryRepository.getCategories();
                displayCategories(catList);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }

        private void displayTotal(object sender, EventArgs e)
        {
            subtotal.Text = cartServices.calculateSubtotal().ToString("N2");
            vat.Text = cartServices.calculateVat().ToString("N2");
            coupon.Text = cartServices.calculateCoupon(couponSelected).ToString("N2");
            total.Text = cartServices.calculateTotalAmount().ToString("N2");
            count.Text = orderList.Count.ToString();
            count.ForeColor = orderList.Count > 0 ? Color.IndianRed : Color.White;
        }

        private void displayMenu(List<MenuModel> menuList)
        {
            foreach (var m in menuList)
            {
                MenuCard card = new MenuCard(menuRepository, m);
                card.Margin = new Padding(12, 10, 12, 10);
                card.orderListEvent += (s, e) =>
                {
                    try
                    {
                        cartServices.addMenuToCart(e);
                        displayTotal(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                };
                card.Visible = false;
                flowMenu.Controls.Add(card);
            }
        }


        private void displayCategories(List<CategoryModel> catList)
        {
            Guna2Button b1 = new Guna2Button();
            b1.Text = "Off Discount";
            //b1.FillColor = Color.FromArgb(238, 238, 238);
            b1.FillColor = Color.Transparent;
            b1.BackColor = Color.Transparent;
            b1.ForeColor = Color.FromArgb(34, 34, 34);
            b1.HoverState.FillColor = Color.FromArgb(238, 238, 238);
            b1.Click += buttonClicked;
            b1.TextOffset = new Point(15, 0);
            b1.Tag = 0;
            buttonClicked(b1, EventArgs.Empty);
            b1.Size = new Size(183, 43);
            b1.Margin = new Padding(0, 0, 102, 0);
            b1.TextAlign = HorizontalAlignment.Left;
            flowCat.Controls.Add(b1);
            foreach (var c in catList)
            {
                Guna2Button b = new Guna2Button();
                b.Text = c.Category_name;
                b.FillColor = Color.Transparent;
                //b.FillColor = Color.FromArgb(238, 238, 238);
                b.BackColor = Color.Transparent;
                b.TextOffset = new Point(15, 0);
                b.ForeColor = Color.FromArgb(34, 34, 34);
                b.TextAlign = HorizontalAlignment.Left;
                b.HoverState.FillColor = Color.FromArgb(238, 238, 238);
                b.Click += buttonClicked;
                b.Tag = c.Category_id;
                b.Size = new Size(183, 43);
                b.Margin = new Padding(0, 0, 0, 0);
                flowCat.Controls.Add(b);
            }
        }
        private void buttonClicked(object sender, EventArgs x)
        {
            Guna2Button b = (Guna2Button)sender;
            int id = (int)b.Tag;
            if (lastActiveButton != null && b != lastActiveButton)
            {
                lastActiveButton.Paint -= bottomBorder;
                lastActiveButton.Invalidate();
                lastActiveButton.ForeColor = Color.FromArgb(34, 34, 34);
            }
            foreach (Control c in flowMenu.Controls)
            {
                if (c is MenuCard r)

                    if (id == 0 && r.Menu.DiscountRate > 0.00)
                    {
                        c.Visible = true;
                    }
                    else
                    {
                        c.Visible = r.Menu.MenuCategory_id == id;
                    }
            }
            {

            }
            b.ForeColor = Color.DarkRed;
            lastActiveButton = b;
            b.Paint -= bottomBorder;
            b.Paint += bottomBorder;
        }
        private void bottomBorder(object sender, PaintEventArgs e)
        {
            Control btn = (sender) as Control;
            using (Pen p = new Pen(Color.DarkRed, 2))
            {
                e.Graphics.DrawLine(p, 0, btn.Height - 2, btn.Width, btn.Height - 2);
                //e.Graphics.DrawLine(p, 0, 3, btn.Width, 3);
            }
        }

        private void KioskLayout_SizeChanged(object sender, EventArgs e)
        {
            x = cartPanel.Location.X;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            t.Start();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            if (isShowing)
            {
                x += 50;
                cartPanel.Location = new Point(x, 0);
                if (x >= ClientSize.Width)
                {
                    cartPanel.Location = new Point(ClientSize.Width, 0);
                    isShowing = !isShowing;
                    t.Stop();
                }
            }
            else
            {
                x -= 62;
                cartPanel.Location = new Point(x, 0);
                if (cartPanel.Right <= ClientSize.Width)
                {
                    int pos = ClientSize.Width - cartPanel.Width;
                    cartPanel.Location = new Point(pos, 0);
                    isShowing = !isShowing;
                    t.Stop();
                }
            }
        }




        private void guna2Button5_Click(object sender, EventArgs eb)
        {
            ICouponRepository couponRepository = new CouponRepository();
            CouponFrm c = new CouponFrm(couponRepository);
            c.CouponSelected += (s, e) => couponSelected = e;
            DialogResult rs = c.ShowDialog(this);
            if (DialogResult.OK == rs)
            {
                displayTotal(this, EventArgs.Empty);
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            CashierLayout m = new CashierLayout();
            m.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderList == null || orderList.Count == 0) return;

                IOrderRepository orderRepository = new OrderRepository();
                OrderServices os = new OrderServices(orderRepository);
                OrderModel or = OrderModel.Builder()
                    .SetOrderList(orderList)
                    .SetCoupon(couponSelected)
                    .Build();

                bool result = os.confirmOrder(or);
                if (result) MessageBox.Show("Order Completed.");
                else MessageBox.Show("Order Failed.");
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
    }
}
