using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySqlConnector;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication;
using OrderingSystem.KioskApplication.Cards;
using OrderingSystem.KioskApplication.Component;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.KioskApplication.Forms;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Repository.Coupon;
using OrderingSystem.Repository.Order;
using OrderingSystem.Services;

namespace OrderingSystem
{
    public partial class KioskLayout : Form
    {
        private readonly List<OrderItemModel> orderList;
        private readonly KioskMenuServices menuServicesKiosk;
        private readonly Dictionary<int, FlowLayoutPanel> categoryPanels;
        private readonly Dictionary<int, Guna2Panel> categoryContainer;
        private readonly List<Guna2Button> buttonListTop;
        private readonly List<Guna2Button> buttonListSide;
        private List<MenuModel> allMenus;
        private Guna2Button lastActiveButtonSide;
        private CartServices cartServices;
        private CouponModel couponSelected;
        private Guna2Button lastClickedTop;

        private bool isFilter = false;
        private bool isShowing = true;
        private int x = 0;
        private int x1 = 20;
        private int basedx = 0;
        public KioskLayout()
        {
            InitializeComponent();
            orderList = new List<OrderItemModel>();
            menuServicesKiosk = new KioskMenuServices(new KioskMenuRepository(orderList));
            buttonListTop = new List<Guna2Button>();
            buttonListSide = new List<Guna2Button>();
            categoryPanels = new Dictionary<int, FlowLayoutPanel>();
            categoryContainer = new Dictionary<int, Guna2Panel>();
            cc.Start();
            dt.Start();
            flowMenu.MouseWheel += FlowMenu_MouseWheel;
        }
        private void lastButton(Guna2Button b)
        {

            foreach (var c in buttonListSide)
            {
                if ((int)c.Tag == (int)b.Tag)
                {
                    c.FillColor = Color.White;
                    c.BackColor = Color.Transparent;
                    c.CustomizableEdges.TopRight = false;
                    c.CustomizableEdges.BottomRight = false;
                    c.AutoRoundedCorners = true;
                    c.ForeColor = Color.FromArgb(34, 34, 34);
                    lastActiveButtonSide.FillColor = Color.FromArgb(9, 119, 206);
                    lastActiveButtonSide.ForeColor = Color.White;
                    lastActiveButtonSide = c;
                    break;
                }
            }
            foreach (var c in buttonListTop)
            {
                if ((int)c.Tag == (int)b.Tag)
                {
                    c.BackColor = Color.Transparent;
                    c.ForeColor = Color.White;
                    c.FillColor = ColorTranslator.FromHtml("#689FF9");
                    lastClickedTop.FillColor = ColorTranslator.FromHtml("#DBEAFE");
                    lastClickedTop.ForeColor = Color.FromArgb(34, 34, 34);
                    lastClickedTop = c;
                    break;
                }
            }
        }
        private void catClickedTop(object sender, EventArgs e)
        {
            Guna2Button b = sender as Guna2Button;
            int catId = (int)b.Tag;

            if (categoryPanels.ContainsKey(catId))
            {
                FlowLayoutPanel p = categoryPanels[catId];
                flowMenu.ScrollControlIntoView(p);
            }
            if (lastClickedTop != null && lastClickedTop != b)
            {
                lastButton(b);
            }
        }
        private void catClickedSide(object sender, EventArgs e)
        {
            Guna2Button b = (Guna2Button)sender;
            int catId = (int)b.Tag;

            if (categoryPanels.ContainsKey(catId))
            {
                FlowLayoutPanel p = categoryPanels[catId];
                flowMenu.ScrollControlIntoView(p);
            }

            if (lastActiveButtonSide != null && b != lastActiveButtonSide)
            {
                lastButton(b);
            }
        }
        private void displayMenu(List<MenuModel> mm)
        {
            foreach (var p in categoryPanels.Values)
                p.Controls.Clear();

            foreach (var p in categoryContainer)
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

                foreach (MenuModel menu in mm)
                {
                    card = new MenuCard(menuServicesKiosk, menu);
                    card.outOfOrder(menu.MaxOrder <= 0);
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
                    foreach (var panel in categoryContainer.Values)
                    {
                        flowMenu.Controls.Add(panel);
                    }
                }
                foreach (MenuModel menu in mm)
                {
                    if (categoryPanels.ContainsKey(menu.CategoryId))
                    {
                        card = new MenuCard(menuServicesKiosk, menu);
                        card.Margin = new Padding(20, 40, 20, 0);
                        card.outOfOrder(menu.MaxOrder <= 0);
                        card.orderListEvent += (s, e) =>
                        {
                            try
                            {
                                cartServices.addMenuToCart(e);
                                displayTotal(this, EventArgs.Empty);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };
                        categoryPanels[menu.CategoryId].Controls.Add(card);
                    }
                }
            }



        }
        private void displayCategory(List<CategoryModel> cats)
        {

            foreach (CategoryModel c in cats)
            {
                Guna2Panel p = new Guna2Panel();
                p.Width = flowMenu.Width - 40;
                p.Margin = new Padding(20, 20, 20, 20);
                p.MaximumSize = new Size(flowMenu.Width - 40, 10000);
                p.AutoSize = true;
                p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                if (c.CategoryName == cats.Last().CategoryName)
                    p.Margin = new Padding(20, 20, 20, 40);

                Title title = new Title(c.CategoryName, c.CategoryImage);
                title.BackColor = Color.Transparent;

                p.Controls.Add(title);

                FlowLayoutPanel flowCat = new FlowLayoutPanel();
                flowCat.MaximumSize = new Size(flowMenu.Width - 40, 10000);
                flowCat.AutoSize = true;
                flowCat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                p.Controls.Add(flowCat);
                flowMenu.Controls.Add(p);

                categoryPanels.Add(c.CategoryId, flowCat);
                categoryContainer.Add(c.CategoryId, p);

                Guna2Button b = new Guna2Button();
                b.Text = c.CategoryName;
                b.Image = c.CategoryImage;
                b.BackColor = Color.Transparent;
                b.ImageSize = new Size(25, 25);
                b.ImageAlign = HorizontalAlignment.Left;
                b.Size = new Size(230, 45);
                b.Tag = c.CategoryId;
                b.Click += catClickedSide;
                b.Margin = new Padding(0);
                b.TextOffset = new Point(20, 0);
                b.TextAlign = HorizontalAlignment.Left;
                b.FillColor = Color.Transparent;
                catFlow.Controls.Add(b);
                buttonListSide.Add(b);

                Guna2Button b1 = new Guna2Button();
                b1.Text = c.CategoryName;
                b1.Size = new Size(200, 35);
                b1.Tag = c.CategoryId;
                b1.Margin = new Padding(0);
                b1.Location = new Point(x1, 90);
                b1.AutoRoundedCorners = true;
                b1.FillColor = ColorTranslator.FromHtml("#DBEAFE");
                b1.Click += catClickedTop;
                b1.BackColor = Color.Transparent;
                b1.ForeColor = Color.FromArgb(34, 34, 34);
                x1 += b1.Size.Width + 5;
                xxx.Controls.Add(b1);
                buttonListTop.Add(b1);
            }
            if (catFlow.Controls.Count > 0)
            {
                lastActiveButtonSide = (Guna2Button)catFlow.Controls[0];
                lastClickedTop = buttonListTop[0];
                lastClickedTop.FillColor = ColorTranslator.FromHtml("#689FF9");
                lastClickedTop.ForeColor = Color.White;
                lastActiveButtonSide.FillColor = Color.White;
                lastActiveButtonSide.BackColor = Color.Transparent;
                lastActiveButtonSide.CustomizableEdges.TopRight = false;
                lastActiveButtonSide.CustomizableEdges.BottomRight = false;
                lastActiveButtonSide.AutoRoundedCorners = true;
                lastActiveButtonSide.ForeColor = Color.FromArgb(34, 34, 34);
            }
        }
        private void displayTotal(object sender, EventArgs e)
        {
            subtotal.Text = cartServices.calculateSubtotal().ToString("N2");
            cdiscount.Text = cartServices.calculateCoupon(couponSelected).ToString("N2");
            total.Text = cartServices.calculateTotalAmount().ToString("N2");
            orderCount.Text = orderList.Count.ToString();
            count2.Text = orderList.Count.ToString();
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
            c.CouponSelected += (s, e) =>
            {
                couponSelected = e;
                displayTotal(this, EventArgs.Empty);
            };
            DialogResult rs = c.ShowDialog(this);
            if (DialogResult.OK == rs)
            {
                displayTotal(this, EventArgs.Empty);
            }
        }
        private void confirmOrder(object sender, EventArgs e)
        {
            try
            {

                if (orderList.Count == 0)
                {
                    MessageBox.Show("No items in the cart.");
                    return;
                }
                IOrderRepository orderRepository = new OrderRepository();
                OrderServices orderServices = new OrderServices(orderRepository);
                string orderId = orderServices.getNewOrderId();
                OrderModel om = OrderModel.Builder()
                                    .WithOrderId(orderId)
                                    .WithOrderItemList(orderList)
                                    .WithCoupon(couponSelected)
                                    .Build();
                OrderLayout l = new OrderLayout(om, orderServices);
                l.AddQuantity += (s, ee) =>
                {

                    foreach (var cc in flowCart.Controls.OfType<CartCard>())
                        if (cc.menu.PurchaseMenu.SizeName == ee.PurchaseMenu.SizeName &&
                        cc.menu.PurchaseMenu.FlavorName == ee.PurchaseMenu.FlavorName &&
                        cc.menu.PurchaseMenu.getPriceAfterVatWithDiscount() == ee.PurchaseMenu.getPriceAfterVatWithDiscount())
                        {
                            cartServices.addQuantity(cc, ee);
                            displayTotal(this, EventArgs.Empty);
                            l.refersh();
                            break;
                        }
                };
                l.DeductQuantity += (s, ee) =>
                {
                    foreach (var cc in flowCart.Controls.OfType<CartCard>())
                        if (cc.menu.PurchaseMenu.SizeName == ee.PurchaseMenu.SizeName &&
                        cc.menu.PurchaseMenu.FlavorName == ee.PurchaseMenu.FlavorName &&
                        cc.menu.PurchaseMenu.getPriceAfterVatWithDiscount() == ee.PurchaseMenu.getPriceAfterVatWithDiscount())
                        {
                            cartServices.deductQuantity(cc, ee);
                            displayTotal(this, EventArgs.Empty);
                            l.refersh();
                            break;
                        }
                };
                l.successfulPayment += (s, ee) =>
                {
                    orderList.Clear();
                    flowCart.Controls.Clear();
                    displayTotal(this, EventArgs.Empty);
                };
                DialogResult rs = l.ShowDialog(this);
                if (rs == DialogResult.OK)
                {
                    l.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void KioskLayout_Load(object sender, EventArgs e)
        {
            try
            {
                CategoryServices categoryServices = new CategoryServices(new CategoryRepository());


                List<CategoryModel> cats = categoryServices.getCategoriesByMenu();
                displayCategory(cats);

                allMenus = menuServicesKiosk.getMenu();
                displayMenu(allMenus);


                cartServices = new CartServices(menuServicesKiosk, flowCart, orderList);
                cartServices.quantityChanged += (s, b) => displayTotal(this, EventArgs.Empty);
            }
            catch (MaxOrder ex)
            {
                MessageBox.Show(ex.Message, "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void triggerCart(object sender, EventArgs e)
        {
            t.Stop();
            t.Start();
        }
        private void debouncing_Tick(object sender, EventArgs e)
        {
            debouncing.Stop();
            string t = txt.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(t))
            {
                isFilter = false;
                flowMenu.Controls.Clear();

                foreach (var panel in categoryContainer.Values)
                {
                    panel.Visible = true;
                    flowMenu.Controls.Add(panel);
                }

                displayMenu(allMenus);
                return;
            }

            isFilter = true;

            var filter = allMenus.FindAll(m =>
                m.MenuName != null && m.MenuName.ToLower().Contains(t)
            );

            displayMenu(filter);
        }
        private void flowMenuScroll()
        {
            Control onScren = null;
            int top = int.MaxValue;

            bool isBottom = flowMenu.VerticalScroll.Value + flowMenu.ClientSize.Height >= flowMenu.VerticalScroll.Maximum;

            if (isBottom)
            {
                top = int.MinValue;
                foreach (var v in categoryPanels)
                {
                    var panel = v.Value;
                    Rectangle scren = panel.RectangleToScreen(panel.ClientRectangle);
                    Rectangle panelRect = flowMenu.RectangleToClient(scren);
                    bool isVisible = panelRect.Bottom > 0 && panelRect.Top < flowMenu.ClientSize.Height;

                    if (isVisible && panelRect.Top > top)
                    {
                        top = panelRect.Top;
                        onScren = panel;
                    }
                }
            }
            else
            {
                foreach (var kvp in categoryPanels)
                {
                    var panel = kvp.Value;

                    Rectangle screenRect = panel.RectangleToScreen(panel.ClientRectangle);
                    Rectangle panelRect = flowMenu.RectangleToClient(screenRect);

                    bool isVisible = panelRect.Bottom > 0 && panelRect.Top < flowMenu.ClientSize.Height;

                    if (isVisible && panelRect.Top < top)
                    {
                        top = panelRect.Top;
                        onScren = panel;
                    }
                }
            }
            if (onScren != null)
            {
                int categoryId = categoryPanels.FirstOrDefault(v => v.Value == onScren).Key;
                var b = buttonListSide.FirstOrDefault(b2 => (int)b2.Tag == categoryId);

                if (b != null && b != lastActiveButtonSide) lastButton(b);
            }
        }
        private void FlowMenu_MouseWheel(object sender, MouseEventArgs e)
        {
            flowMenuScroll();
        }
        private void cc_Tick(object sender, EventArgs e)
        {
            foreach (var btn in buttonListTop)
            {
                int x2 = btn.Location.X - 2;
                if (x2 + btn.Width < 0)
                {
                    int x3 = buttonListTop.Max(b => b.Location.X + b.Width);
                    x2 = x3 + 10;
                }
                btn.Location = new Point(x2, btn.Location.Y);
            }

        }
        private void flowMenu_Scroll(object sender, ScrollEventArgs e)
        {
            flowMenuScroll();
        }
        private void dt_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            date.Text = DateTime.Now.ToString("yyyy, MMMM dd");
            week.Text = DateTime.Now.DayOfWeek.ToString();
        }
    }
}
