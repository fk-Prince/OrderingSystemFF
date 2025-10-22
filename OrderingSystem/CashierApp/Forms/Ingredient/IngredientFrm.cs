using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.FactoryForm;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class IngredientFrm : Form
    {
        private IForms f;
        public IngredientFrm()
        {
            InitializeComponent();
            f = new FormFactory();
        }


        public void showAddIngredient()
        {
            PopupForm add = new PopupForm();
            DialogResult rs = f.selectForm(add, "add-ingredients").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                add.Hide();
            }

        }

        public void showDeductIngredient()
        {
            PopupForm ded = new PopupForm();
            DialogResult rs = ded.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                ded.Hide();
            }

        }

        public void showRestockIngredient()
        {
            PopupForm add = new PopupForm();
            DialogResult rs = f.selectForm(add, "restock-ingredients").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                add.Hide();
            }
        }
    }
}
