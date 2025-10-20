using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.CashierApp.Components
{
    public partial class IngredientMenu : Form
    {
        private DataTable table;
        private readonly IIngredientRepository ingredientRepository;
        private DataView view;
        private List<IngredientModel> ingredientList;
        private List<IngredientModel> ingredientSelected;
        public event EventHandler<List<IngredientModel>> IngredientSelectedEvent;
        public IngredientMenu(IIngredientRepository ingredientRepository)
        {
            InitializeComponent();
            this.ingredientRepository = ingredientRepository;
            ingredientSelected = new List<IngredientModel>();
        }
        public void getIngredientByMenu(MenuModel variantDetail)
        {
            ingredientList = ingredientRepository.getIngredientsOfMenu(variantDetail);
        }
        public void getIngredient()
        {
            ingredientList = ingredientRepository.getIngredients();
        }
        public void initTable1()
        {
            table = new DataTable();
            table.Columns.Add("Ingredient Name");
            table.Columns.Add("Quantity");
            table.Columns.Add("Unit");

            ingredientList.ForEach(e => table.Rows.Add(e.IngredientName, e.IngredientQuantity, e.IngredientUnit));
            view = new DataView(table);
            dataGrid.DataSource = view;
            dataGrid.Enabled = false;
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
        public void initTable2()
        {
            table = new DataTable();
            table.Columns.Add("Select", typeof(bool));
            table.Columns.Add("Ingredient Name");
            table.Columns.Add("Unit");
            table.Columns.Add("Quantity");

            ingredientList.ForEach(e => table.Rows.Add(e.IngredientQuantity != 0, e.IngredientName, e.IngredientUnit, e.IngredientQuantity == 0 ? DBNull.Value : (object)e.IngredientQuantity));
            view = new DataView(table);
            dataGrid.DataSource = view;

            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.DataPropertyName = "Select";

            dataGrid.Columns[0].Width = 48;
            dataGrid.Columns[2].Width = 70;
            dataGrid.Enabled = true;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dataGrid.Enabled = true;
            table.Rows.Clear();
            table.Columns.Clear();
            initTable2();
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
        private void search_TextChanged(object sender, EventArgs e)
        {
            string tx = search.Text.Trim().Replace("'", "''");
            view.RowFilter = string.IsNullOrEmpty(tx) ? "" : $"[Ingredient Name] LIKE '%{tx}%'";
        }
        private void submit(object sender, EventArgs e)
        {

            ingredientSelected.Clear();
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
                else
                {
                    string ingredientName = row.Cells["Ingredient Name"].Value?.ToString();
                    var selectedIngredient = ingredientList.Find(x => x.IngredientName == ingredientName);
                    if (selectedIngredient != null)
                    {
                        ingredientSelected.Remove(selectedIngredient);
                    }
                }
            }

            IngredientSelectedEvent?.Invoke(this, ingredientSelected);
        }
        public void reset()
        {
            ingredientSelected.Clear();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
