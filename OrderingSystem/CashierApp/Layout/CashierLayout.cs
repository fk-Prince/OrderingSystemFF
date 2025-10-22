using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.CashierApp.Forms.Staffs;
using OrderingSystem.CashierApp.Layout;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class CashierLayout : Form
    {
        private IngredientFrm ingredientInstance;
        private MenuFrm menuIntance;
        private Guna2Button lastClicked;
        private StaffModel staff;
        private CashierLayout instance;
        public CashierLayout(StaffModel staff)
        {
            InitializeComponent();
            if (instance == null)
                instance = this;
            this.staff = staff;
            loadForm(OrderFrm.OrderInstance(staff));
            lastClicked = orderButton;
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
        private void showSub(Panel panel)
        {
            if (panel.Visible == false && staff.Role.ToLower() == "manager")
            {
                hideSubMenu();
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
        }

        private void hideSubMenu()
        {
            if (s1.Visible == true && staff.Role.ToLower() == "manager") s1.Visible = false;
            if (s2.Visible == true && staff.Role.ToLower() == "manager") s2.Visible = false;
        }
        private void guna2Button14_Click(object sender, System.EventArgs e)
        {
            loadForm(OrderFrm.OrderInstance(staff));
            hideSubMenu();
        }
        private void showMenu(object sender, System.EventArgs e)
        {
            loadForm(menuIntance = new MenuFrm());
            showSub(s1);
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
        private void showIngredient(object sender, System.EventArgs e)
        {
            showSub(s2);
            loadForm(ingredientInstance = new IngredientFrm());
        }
        private void restockIngredient(object sender, System.EventArgs e)
        {
            IForms f = new FormFactory();
            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                FactoryFormServices.saveFormData((PopupForm)ss, "restock-ingredients");
            };
            DialogResult rs = f.selectForm(p, "restock-ingredients").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        private void addIngredient(object sender, System.EventArgs e)
        {
            IForms f = new FormFactory();
            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                FactoryFormServices.saveFormData((PopupForm)ss, "add-ingredients");
            };
            DialogResult rs = f.selectForm(p, "add-ingredients").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        private void deductIngredient(object sender, System.EventArgs e)
        {
            if (ingredientInstance == null) return;
            ingredientInstance.showDeductIngredient();
        }

        private void buttonClicked(object sender, MouseEventArgs e)
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

        private void inventoryClicked(object sender, System.EventArgs e)
        {
            hideSubMenu();
        }

        private void staffClicked(object sender, System.EventArgs e)
        {
            hideSubMenu();
            loadForm(new StaffFrm(staff));
        }



        private void signout_Click(object sender, System.EventArgs e)
        {
            Hide();
            LoginLayout ll = new LoginLayout();
            ll.Show();
        }

        private void su_Click(object sender, System.EventArgs e)
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
        private void couponCodeButton(object sender, System.EventArgs e)
        {
            IForms f = new FormFactory();
            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                FactoryFormServices.saveFormData((PopupForm)ss, "Coupon");
            };
            DialogResult rs = f.selectForm(p, "coupon").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
    }
}
