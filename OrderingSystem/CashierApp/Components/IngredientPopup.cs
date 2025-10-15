using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.CashierApp.Components
{
    public partial class IngredientPopup : Form
    {
        private DataTable table;
        private DataView view;
        private List<IngredientModel> ingredientSelected;
        private List<IngredientModel> ingredientList;
        public event EventHandler<List<IngredientModel>> buttonClicked;


        public IngredientPopup(string title)
        {
            InitializeComponent();
            IIngredientRepository ingredientRepository = new IngredientRepository();
            ingredientList = ingredientRepository.getIngredients();
            ingredientSelected = new List<IngredientModel>();
            bb.Text = title;
        }
        public void ingredientSelector(List<IngredientModel> ingredientSelected)
        {
            this.ingredientSelected = ingredientSelected;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[3].Value != null && row.Cells[0].Value != null && bool.TryParse(row.Cells[0].Value.ToString(), out bool val))
                {
                    string ingredientName = row.Cells["Ingredient Name"].Value?.ToString();
                    var selectedIngredient = ingredientSelected.Find(x => x.IngredientName == ingredientName);
                    if (selectedIngredient != null)
                    {
                        row.Cells["Select"].Value = true;
                        row.Cells["Quantity"].Value = selectedIngredient.IngredientQuantity.ToString();
                    }
                }

            }
        }


        public void initTable()
        {
            table = new DataTable();
            table.Columns.Add("Select", typeof(bool));
            table.Columns.Add("Ingredient Name");
            table.Columns.Add("Unit");
            table.Columns.Add("Quantity");


            ingredientList.ForEach(e => table.Rows.Add(false, e.IngredientName, e.IngredientUnit, DBNull.Value));
            view = new DataView(table);
            dataGrid.DataSource = view;

            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.DataPropertyName = "Select";

            dataGrid.Columns[0].Width = 48;
            dataGrid.Columns[2].Width = 70;
        }
        private void dataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGrid.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string input = e.FormattedValue?.ToString().Trim();

                if (string.IsNullOrEmpty(input))
                    return;

                string pattern = @"^(?:\d{1,3}(?:,\d{3})*|\d+)?(?:\.\d+)?$";

                if (!Regex.IsMatch(input, pattern))
                {
                    MessageBox.Show("Invalid iNptu");
                    e.Cancel = true;
                }
            }
        }
        private void bb_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                bool check = false;
                if (row.Cells[3].Value != null && row.Cells[0].Value != null && bool.TryParse(row.Cells[0].Value.ToString(), out bool val))
                {
                    check = val;
                }

                if (check)
                {
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int quantity) && quantity > 0)
                    {

                        string ingredientName = row.Cells["Ingredient Name"].Value?.ToString();

                        var selectedIngredient = ingredientList.Find(x => x.IngredientName == ingredientName);
                        if (selectedIngredient != null)
                        {
                            IngredientModel ingredient = IngredientModel.Builder()
                                .SetIngredient_id(selectedIngredient.Ingredient_id)
                                .SetIngredientName(ingredientName)
                                .SetIngredientQuantity(quantity)
                                .Build();
                            ingredientSelected.Add(ingredient);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is an empty quantity field");
                        return;
                    }
                }
            }
            buttonClicked.Invoke(this, ingredientSelected);
            DialogResult = DialogResult.OK;
        }
        private void search_TextChanged(object sender, System.EventArgs e)
        {
            string tx = search.Text.Trim().Replace("'", "''");
            view.RowFilter = string.IsNullOrEmpty(tx) ? "" : $"[Ingredient Name] LIKE '%{tx}%'";
        }
        public void reset()
        {
            ingredientSelected.Clear();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
