using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.Category;
using OrderingSystem.CashierApp.Forms.Coupon;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.CashierApp.Forms.Staffs;
using OrderingSystem.CashierApp.Layout;
using OrderingSystem.Model;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Repository.Reports;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class CashierLayout : Form
    {
        private IngredientFrm ingredientInstance;
        private MenuFrm menuIntance;
        private Guna2Button lastClicked;
        private readonly StaffModel staff;
        private readonly IForms iForms;
        public CashierLayout(StaffModel staff)
        {
            InitializeComponent();
            this.staff = staff;
            iForms = new FormFactory();

            lastClicked = orderButton;
            loadForm(new OrderFrm(staff));
            displayStaffDetails();
        }

        private void displayStaffDetails()
        {
            if (staff.Role.ToLower() != "manager")
            {
                nm.Visible = false;
                nb.Visible = false;
                ri.Visible = false;
                ai.Visible = false;
                ri.Visible = false;
            }
            image.Image = staff.Image;
            name.Text = staff.FirstName.Substring(0, 1).ToUpper() + staff.FirstName.Substring(1).ToLower() + "  " + staff.LastName.Substring(0, 1).ToUpper() + staff.LastName.Substring(1).ToLower();
            role.Text = staff.Role.Substring(0, 1).ToUpper() + staff.Role.Substring(1);
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
            if (panel.Visible == false && staff.Role.ToLower() == "manager")
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
            if (s1.Visible == true && staff.Role.ToLower() == "manager") s1.Visible = false;
            if (s2.Visible == true && staff.Role.ToLower() == "manager") s2.Visible = false;
        }
        private void viewOrder(object sender, System.EventArgs e)
        {
            loadForm(new OrderFrm(staff));
            hideSubPanel();
        }
        private void showMenu(object sender, System.EventArgs e)
        {
            loadForm(menuIntance = new MenuFrm(staff));
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
            loadForm(ingredientInstance = new IngredientFrm());
        }
        private void viewRestockIngredient(object sender, System.EventArgs e)
        {
            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                //FactoryFormServices.saveFormData((PopupForm)ss, "restock-ingredients");
            };
            DialogResult rs = iForms.selectForm(p, "restock-ingredients").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        private void viewAddIngredients(object sender, System.EventArgs e)
        {

            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                //FactoryFormServices.saveFormData((PopupForm)ss, "add-ingredients");
            };
            DialogResult rs = iForms.selectForm(p, "add-ingredients").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        private void viewDeductIngredient(object sender, System.EventArgs e)
        {
            if (ingredientInstance == null) return;
            ingredientInstance.showDeductIngredient();
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
            loadForm(new InventoryFrm(staff, new InventoryServices(new InventoryReportsRepository())));
        }
        private void viewStaff(object sender, System.EventArgs e)
        {
            hideSubPanel();
            loadForm(new StaffFrm(staff));
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
            CouponFrm c = new CouponFrm(iForms, new CouponServices(), staff);
            loadForm(c);
        }

        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
            CategoryFrm c = new CategoryFrm(new CategoryServices(new CategoryRepository()), staff);
            loadForm(c);
        }
    }
}
