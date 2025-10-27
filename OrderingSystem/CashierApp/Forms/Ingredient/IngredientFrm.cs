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
        private IngredientServices ingredientServices;
        public IngredientFrm()
        {
            InitializeComponent();
            ingredientServices = new IngredientServices(new IngredientRepository());
            updateTable();
        }

        public void updateTable()
        {
            check.Checked = false;
            txt.Text = "";
            view = ingredientServices.getIngredientsView();
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

        private void bb_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you want to remove expired ingredient?", "Deduct", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    bool suc = ingredientServices.removeExpiredIngredient();
                    if (suc)
                    {
                        MessageBox.Show("Successful Removed", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateTable();
                    }
                    else MessageBox.Show("Failed to remove expired ingredient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
