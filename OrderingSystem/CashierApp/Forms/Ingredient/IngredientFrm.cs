using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.Ingredient;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class IngredientFrm : Form
    {
        public IngredientFrm()
        {
            InitializeComponent();

        }


        public void showAddIngredient()
        {
            AddIngredient add = new AddIngredient();
            DialogResult rs = add.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                add.Hide();
            }

        }

        public void showDeductIngredient()
        {
            DeductIngredient ded = new DeductIngredient();
            DialogResult rs = ded.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                ded.Hide();
            }

        }

        public void showRestockIngredient()
        {
            RestockIngredient re = new RestockIngredient();
            DialogResult rs = re.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                re.Hide();
            }

        }
    }
}
