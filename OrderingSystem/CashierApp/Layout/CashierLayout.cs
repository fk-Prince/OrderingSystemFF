using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class CashierLayout : Form
    {
        private IngredientFrm ingredientInstance;
        private MenuFrm menuIntance;
        private Guna2Button lastClicked;
        public CashierLayout()
        {
            InitializeComponent();
            loadForm(OrderFrm.orderFactory());
            lastClicked = orderButton;
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
            if (panel.Visible == false)
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
            if (s1.Visible == true) s1.Visible = false;
            if (s2.Visible == true) s2.Visible = false;
        }
        private void guna2Button14_Click(object sender, System.EventArgs e)
        {
            loadForm(OrderFrm.orderFactory());
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
            if (ingredientInstance == null) return;
            ingredientInstance.showRestockIngredient();
        }
        private void addIngredient(object sender, System.EventArgs e)
        {
            if (ingredientInstance == null) return;
            ingredientInstance.showAddIngredient();
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

        private void utilitiesClicked(object sender, System.EventArgs e)
        {
            hideSubMenu();
        }


    }
}
