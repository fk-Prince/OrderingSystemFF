using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.Repository.Ingredients;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class IngredientFrm : Form
    {
        private IForms f;
        private DataView view;
        public IngredientFrm()
        {
            InitializeComponent();
            f = new FormFactory();
            view = new IngredientServices(new IngredientRepository()).getIngredientsView();
            dataGrid.DataSource = view;
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

        private void textChanged(object sender, System.EventArgs e)
        {
            loadIngredientData();
        }

        public void loadIngredientData()
        {
            string ingredientQuery = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
            string expiryFilter = "";
            if (check.Checked)
                expiryFilter = $"[Expiry Date] <= #{DateTime.Now:yyyy-MM-dd}#";
            else
                expiryFilter = $"[Expiry Date] > #{DateTime.Now:yyyy-MM-dd}#";

            string finalFilter = string.Join(" OR ", new[] { ingredientQuery, expiryFilter }.Where(f => !string.IsNullOrEmpty(f)));
            view.RowFilter = finalFilter;
        }

        private void checkboxChanged(object sender, System.EventArgs e)
        {
            loadIngredientData();
        }

    }
}
