using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Repository.Ingredients;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class IngredientFrm : Form
    {
        private DataView view;
        public IngredientFrm()
        {
            InitializeComponent();
            updateTable();
        }

        public void updateTable()
        {
            check.Checked = false;
            txt.Text = "";
            view = new IngredientServices(new IngredientRepository()).getIngredientsView();
            dataGrid.DataSource = view;
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
