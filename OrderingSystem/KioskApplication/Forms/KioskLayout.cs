using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication;
using OrderingSystem.KioskApplication.Cards;
using OrderingSystem.KioskApplication.Component;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Repository.Coupon;
using OrderingSystem.Repository.Order;

namespace OrderingSystem
{
    public partial class KioskLayout : Form
    {
        private IKioskMenuRepository _menuRepository;
        private Dictionary<int, FlowLayoutPanel> _categoryPanels;
        private Dictionary<int, Guna2Panel> _categoryCons;
        private List<MenuModel> _orderList;
        private List<MenuModel> _allMenus;
        private Guna2Button lastActiveButton;
        private bool isFilter = false;
        private CartServices cartServices;
        private CouponModel couponSelected;

        // CART PROPERTIES
        private bool isShowing = true;
        private int x = 0;
        private int basedx = 0;

        public KioskLayout()
        {
            InitializeComponent();
            _orderList = new List<MenuModel>();
            _categoryPanels = new Dictionary<int, FlowLayoutPanel>();
            _categoryCons = new Dictionary<int, Guna2Panel>();
        }

        private void KioskLayout_Load(object sender, EventArgs e)
        {
            _menuRepository = new KioskMenuRepository(_orderList);
            ICategoryRepository categoryRepository = new CategoryRepository();

            List<CategoryModel> cats = categoryRepository.getCategories();
            displayCategory(cats);

            _allMenus = _menuRepository.getMenu();
            displayMenu(_allMenus);

            cartServices = new CartServices(_menuRepository, flowCart, _orderList);
            cartServices.quantityChanged += (s, b) => displayTotal(this, EventArgs.Empty);
        }
        private void displayCategory(List<CategoryModel> cats)
        {
            foreach (CategoryModel c in cats)
            {
                Guna2Panel p = new Guna2Panel();
                p.Width = flowMenu.Width - 40;
                //p.Padding = new Padding(20, 0, 20, 0);
                p.Margin = new Padding(20, 20, 20, 20);
                p.MaximumSize = new Size(flowMenu.Width - 40, 10000);
                p.AutoSize = true;
                p.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                Title title = new Title(c.CategoryName);
                title.BackColor = Color.Transparent;

                p.Controls.Add(title);

                FlowLayoutPanel flowCat = new FlowLayoutPanel();
                flowCat.MaximumSize = new Size(flowMenu.Width - 40, 10000);
                flowCat.AutoSize = true;
                flowCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p.Controls.Add(flowCat);
                flowMenu.Controls.Add(p);

                _categoryPanels.Add(c.CategoryId, flowCat);
                _categoryCons.Add(c.CategoryId, p);

                Guna2Button b = new Guna2Button();
                b.Text = c.CategoryName;
                b.Size = new Size(230, 45);
                b.Tag = c.CategoryId;
                b.Click += catClicked;
                b.Margin = new Padding(0);
                b.TextOffset = new Point(20, 0);
                b.TextAlign = HorizontalAlignment.Left;
                b.FillColor = Color.Transparent;
                catFlow.Controls.Add(b);
            }

            if (catFlow.Controls.Count > 0)
            {
                lastActiveButton = (Guna2Button)catFlow.Controls[0];
                lastActiveButton.Paint += bottomBorder;
            }
        }
        private void catClicked(object sender, EventArgs e)
        {
            Guna2Button b = (Guna2Button)sender;
            int catId = (int)b.Tag;

            if (_categoryPanels.ContainsKey(catId))
            {
                FlowLayoutPanel p = _categoryPanels[catId];
                flowMenu.ScrollControlIntoView(p);
            }

            if (lastActiveButton != null && b != lastActiveButton)
            {
                lastActiveButton.Paint -= bottomBorder;
                lastActiveButton.Invalidate();
            }

            lastActiveButton = b;
            b.Paint -= bottomBorder;
            b.Paint += bottomBorder;
        }
        private void bottomBorder(object sender, PaintEventArgs e)
        {
            Control btn = (sender) as Control;
            using (Pen p = new Pen(Color.FromArgb(255, 255, 255), 2))
            {
                e.Graphics.DrawLine(p, 0, btn.Height - 2, btn.Width, btn.Height - 2);
            }
        }
        private void displayMenu(List<MenuModel> menusToDisplay)
        {
            foreach (var p in _categoryPanels.Values)
                p.Controls.Clear();

            foreach (var p in _categoryCons)
                p.Value.Visible = !isFilter;

            MenuCard card = null;
            if (isFilter)
            {

                flowMenu.Controls.Clear();

                FlowLayoutPanel flatPanel = new FlowLayoutPanel();
                flatPanel.MaximumSize = new Size(flowMenu.Width - 40, 10000);
                flatPanel.AutoSize = true;
                flatPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flatPanel.Margin = new Padding(10);

                foreach (MenuModel menu in menusToDisplay)
                {
                    card = new MenuCard(_menuRepository, menu);
                    card.Margin = new Padding(20, 20, 20, 0);
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
                    flatPanel.Controls.Add(card);
                }
                flowMenu.Controls.Add(flatPanel);
            }
            else
            {

                if (flowMenu.Controls.Count == 0)
                {
                    foreach (var panel in _categoryCons.Values)
                    {
                        flowMenu.Controls.Add(panel);
                    }
                }

                foreach (MenuModel menu in menusToDisplay)
                {
                    if (_categoryPanels.ContainsKey(menu.CategoryId))
                    {
                        card = new MenuCard(_menuRepository, menu);
                        card.Margin = new Padding(20, 40, 20, 0);
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
                        _categoryPanels[menu.CategoryId].Controls.Add(card);
                    }
                }
            }

        }
        private void displayTotal(object sender, EventArgs e)
        {
            subtotal.Text = cartServices.calculateSubtotal().ToString("N2");
            vat.Text = cartServices.calculateVat().ToString("N2");
            cdiscount.Text = cartServices.calculateCoupon(couponSelected).ToString("N2");
            total.Text = cartServices.calculateTotalAmount().ToString("N2");
            orderCount.Text = _orderList.Count.ToString();
            count2.Text = _orderList.Count.ToString();
        }
        private void searchedMenu(object sender, EventArgs e)
        {
            debouncing.Stop();
            debouncing.Start();
        }
        private void couponOption(object sender, EventArgs bx)
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
        private void confirmOrder(object sender, EventArgs e)
        {
            if (_orderList.Count == 0)
            {
                MessageBox.Show("No items in the cart.");
                return;
            }
            IOrderRepository orderRepository = new OrderRepository();
            OrderServices orderServices = new OrderServices(orderRepository);
            orderServices.confirmOrder(
                            OrderModel.Builder()
                            .SetOrderList(_orderList)
                            .SetCoupon(couponSelected)
                            .Build()
                           );

        }
        private void t_Tick(object sender, EventArgs e)
        {
            if (isShowing)
            {
                x += 20;
                if (x >= this.Width)
                {
                    x = this.Width;
                    isShowing = false;
                    t.Stop();
                }

            }
            else
            {
                x -= 20;
                if (x <= basedx)
                {
                    x = basedx;
                    t.Stop();
                    isShowing = true;
                }

            }
            cartPanel.Location = new Point(x, cartPanel.Location.Y);
        }
        private void KioskLayout_SizeChanged(object sender, EventArgs e)
        {
            x = cartPanel.Location.X;
            basedx = x;
        }
        private void triggerCart(object sender, EventArgs e)
        {
            t.Stop();
            t.Start();
        }
        private void debouncing_Tick(object sender, EventArgs e)
        {
            debouncing.Stop();
            string t = guna2TextBox1.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(t))
            {
                isFilter = false;
                flowMenu.Controls.Clear();

                foreach (var panel in _categoryCons.Values)
                {
                    panel.Visible = true;
                    flowMenu.Controls.Add(panel);
                }

                displayMenu(_allMenus);
                return;
            }

            isFilter = true;

            var filter = _allMenus.FindAll(m =>
                m.MenuName != null && m.MenuName.ToLower().Contains(t)
            );

            displayMenu(filter);
        }
    }
}
