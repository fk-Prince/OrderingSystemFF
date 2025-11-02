using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.Category;
using OrderingSystem.CashierApp.Forms.Coupon;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.CashierApp.Forms.Ingredient;
using OrderingSystem.CashierApp.Forms.Menu;
using OrderingSystem.CashierApp.Forms.Staffs;
using OrderingSystem.CashierApp.Layout;
using OrderingSystem.CashierApp.SessionData;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Repository.Reports;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class CashierLayout : Form
    {
        private IngredientPanel ingredientPanel;
        private IngredientFrm instance;
        private MenuFrm menuIntance;
        private Guna2Button lastClicked;

        private readonly IForms iForms;
        public CashierLayout()
        {
            InitializeComponent();
            dts.Start();
            iForms = new FormFactory();
            ingredientPanel = new IngredientPanel(iForms);


            lastClicked = orderButton;
            loadForm(new OrderFrm());
            displayStaffDetails();
        }

        private void displayStaffDetails()
        {
            if (SessionStaffData.Role.ToLower() != "manager")
            {
                nm.Visible = false;
                nb.Visible = false;
                ri.Visible = false;
                ai.Visible = false;
                ri.Visible = false;
                md.Visible = false;
            }
            image.Image = SessionStaffData.Image;
            name.Text = SessionStaffData.FirstName.Substring(0, 1).ToUpper() + SessionStaffData.FirstName.Substring(1).ToLower() + "  " + SessionStaffData.LastName.Substring(0, 1).ToUpper() + SessionStaffData.LastName.Substring(1).ToLower();
            role.Text = SessionStaffData.Role.Substring(0, 1).ToUpper() + SessionStaffData.Role.Substring(1);
        }
        public void loadForm(Form f)
        {
            if (mm.Tag is Form ff && ff.Name == f.Name) return;
            if (mm.Controls.Count > 0) mm.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mm.Controls.Add(f);
            mm.Tag = f;
            f.Show();
        }
        private void showSubPanel(Panel panel)
        {
            if (panel.Visible == false && SessionStaffData.Role.ToLower() == "manager")
            {
                hideSubPanel();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }
        private void hideSubPanel()
        {
            if (s1.Visible == true && SessionStaffData.Role.ToLower() == "manager") s1.Visible = false;
            if (s2.Visible == true && SessionStaffData.Role.ToLower() == "manager") s2.Visible = false;
        }
        private void viewOrder(object sender, System.EventArgs e)
        {
            loadForm(new OrderFrm());
            hideSubPanel();
        }
        private void showMenu(object sender, System.EventArgs e)
        {
            loadForm(menuIntance = new MenuFrm());
            showSubPanel(s1);
        }
        private void newMenu(object sender, System.EventArgs e)
        {
            if (menuIntance == null) return;
            menuIntance.showNewMenu();

        }
        private void bundleMenu(object sender, System.EventArgs e)
        {

            if (menuIntance == null) return;
            menuIntance.showBundle();
        }

        private void viewIngredient(object sender, System.EventArgs e)
        {
            showSubPanel(s2);
            loadForm(instance = new IngredientFrm());
        }
        private void viewRestockIngredient(object sender, System.EventArgs e)
        {
            ingredientPanel.IngredientUpdated += (ss, ee) => instance.updateTable();
            ingredientPanel.PopupRestockIngredient(this);
        }
        private void viewAddIngredients(object sender, System.EventArgs e)
        {
            ingredientPanel.IngredientUpdated += (ss, ee) => instance.updateTable();
            ingredientPanel.PopupAddIngredient(this);
        }
        private void viewDeductIngredient(object sender, System.EventArgs e)
        {
            ingredientPanel.IngredientUpdated += (ss, ee) => instance.updateTable();
            ingredientPanel.PopupDeductIngredient(this);
        }

        private void primaryButtonClickedSide(object sender, MouseEventArgs e)
        {
            Guna2Button b = sender as Guna2Button;
            if (lastClicked != b)
            {
                b.FillColor = Color.White;
                b.BackColor = Color.Transparent;
                b.CustomizableEdges.TopRight = false;
                b.CustomizableEdges.BottomRight = false;
                b.AutoRoundedCorners = true;
                b.ForeColor = Color.FromArgb(34, 34, 34);
                lastClicked.FillColor = Color.FromArgb(9, 119, 206);
                lastClicked.ForeColor = Color.White;
                lastClicked = b;
            }
        }
        private void viewInventory(object sender, System.EventArgs e)
        {
            hideSubPanel();
            loadForm(new ReportsFrm(new ReportServices(new InventoryReportsRepository())));
        }
        private void viewStaff(object sender, System.EventArgs e)
        {
            hideSubPanel();
            loadForm(new StaffFrm());
        }
        private void signoutUser(object sender, System.EventArgs e)
        {
            Hide();
            LoginLayout ll = new LoginLayout();
            ll.Show();
        }
        private void switchUser(object sender, System.EventArgs e)
        {
            LoginLayout ll = new LoginLayout();
            ll.isPopup = true;
            DialogResult rs = ll.ShowDialog(this);
            if (rs == DialogResult.OK)
            {

                if (ll.isLogin)
                {
                    Hide();
                }
                ll.Hide();
            }
        }
        private void viewCoupon(object sender, System.EventArgs e)
        {
            CouponFrm c = new CouponFrm(iForms, new CouponServices());
            loadForm(c);
        }
        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
            CategoryFrm c = new CategoryFrm(new CategoryServices(new CategoryRepository()));
            loadForm(c);
        }

        private void dts_Tick(object sender, System.EventArgs e)
        {
            time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            date.Text = DateTime.Now.ToString("yyyy, MMMM dd - dddd");
        }

        private void menuDiscount(object sender, EventArgs e)
        {
            MenuDiscountPanel md = new MenuDiscountPanel(new FormFactory());
            md.AddDiscountPopup(this);
        }
    }
}
