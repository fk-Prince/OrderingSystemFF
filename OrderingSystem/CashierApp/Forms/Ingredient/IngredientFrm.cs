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
            AddIngredient add = new AddIngredient();
            DialogResult rs = add.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                add.Hide();
            }
            //loadForm(new AddIngredient());
        }

        public void showDeductIngredient()
        {
            DeductIngredient ded = new DeductIngredient();
            DialogResult rs = ded.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                ded.Hide();
            }
            //loadForm(new DeductIngredient());
        }

        public void showRestockIngredient()
        {
            RestockIngredient re = new RestockIngredient();
            DialogResult rs = re.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                re.Hide();
            }
            //loadForm(new RestockIngredient());
        }
    }
}
