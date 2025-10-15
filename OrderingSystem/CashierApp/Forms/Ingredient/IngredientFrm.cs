using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.Ingredient;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class IngredientFrm : Form
    {
        public IngredientFrm()
        {
            InitializeComponent();
            // FILE PATH
            // INGREDIENT BUILDER => MODELS / INGREDIENTMODEL
        }

        public void loadForm(Form f)
        {
            if (mm.Controls.Count > 0) mm.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mm.Controls.Add(f);
            mm.Tag = f;
            f.Show();
        }

        public void showAddIngredient()
        {
            loadForm(new AddIngredient());
        }

        public void showDeductIngredient()
        {
            loadForm(new DeductIngredient());
        }

        public void showRestockIngredient()
        {
            loadForm(new RestockIngredient());
        }
    }
}
