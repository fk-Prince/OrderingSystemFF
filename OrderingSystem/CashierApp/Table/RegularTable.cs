using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.CashierApp.Components
{
    public partial class RegularTable : Form
    {
        private List<MenuModel> variants;
        private DataTable table;
        private readonly IIngredientRepository ingredientRepository;

        public RegularTable(List<MenuModel> variants, IIngredientRepository ingredientRepository)
        {
            InitializeComponent();
            this.variants = variants;
            this.ingredientRepository = ingredientRepository;
            displayMenu();
        }

        private void displayMenu()
        {

            table = new DataTable();
            table.Columns.Add("Flavor");
            table.Columns.Add("Size");
            table.Columns.Add("Prep Estimated Time");
            table.Columns.Add("Price");
            variants.ForEach(v => table.Rows.Add(v.FlavorName, v.SizeName, v.EstimatedTime, v.MenuPrice));
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = table;

            dataGrid.Columns.Clear();


            List<string> flavors = new MenuRepository().getFlavor();
            List<string> sizes = new MenuRepository().getSize();
            DataGridViewComboBoxColumn flavorCombo = new DataGridViewComboBoxColumn();
            flavorCombo.Name = "Flavor";
            flavorCombo.HeaderText = "Flavor";
            flavorCombo.DataSource = flavors;
            flavorCombo.DataPropertyName = "Flavor";
            flavorCombo.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGrid.Columns.Add(flavorCombo);


            DataGridViewComboBoxColumn sizeCombo = new DataGridViewComboBoxColumn();
            sizeCombo.Name = "Size";
            sizeCombo.HeaderText = "Size";
            sizeCombo.DataSource = sizes;
            sizeCombo.DataPropertyName = "Size";
            sizeCombo.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dataGrid.Columns.Add(sizeCombo);


            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.Name = "Prep Estimated Time";
            timeColumn.HeaderText = "Prep Estimated Time";
            timeColumn.DataPropertyName = "Prep Estimated Time";
            dataGrid.Columns.Add(timeColumn);


            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.DataPropertyName = "Price";
            dataGrid.Columns.Add(priceColumn);


            DataGridViewButtonColumn ingredientsButtonColumn = new DataGridViewButtonColumn();
            ingredientsButtonColumn.Name = "ViewIngredients";
            ingredientsButtonColumn.HeaderText = "Ingredients";
            ingredientsButtonColumn.Text = "View Ingredients";
            ingredientsButtonColumn.UseColumnTextForButtonValue = true;
            dataGrid.Columns.Add(ingredientsButtonColumn);

            dataGrid.EditingControlShowing += (s, e) =>
            {
                if (e.Control is ComboBox cb)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                    cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            };

            dataGrid.CellContentClick += (s, e) =>
            {
                if (e.ColumnIndex == dataGrid.Columns["ViewIngredients"].Index && e.RowIndex >= 0)
                {
                    var variantDetail = variants[e.RowIndex];
                    IngredientMenu im = new IngredientMenu(ingredientRepository);
                    im.IngredientSelectedEvent += (ss, ee) =>
                    {
                        List<IngredientModel> ingredientSelected = ee;
                        if (ingredientSelected.Count > 0)
                        {
                            bool suc = ingredientRepository.saveIngredientByMenu(variantDetail.MenuDetailId, ingredientSelected, "Regular");
                            if (suc)
                            {
                                MessageBox.Show("Ingredient Updated.");
                                im.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Ingredient ex.");
                            }
                        }
                    };
                    im.getIngredientByMenu(variantDetail);
                    im.initTable1();
                    im.updateButton.Visible = true;
                    im.confirmButton.Visible = true;
                    DialogResult rs = im.ShowDialog(this);
                    if (rs == DialogResult.OK)
                    {
                        im.Hide();
                    }
                }
            };
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
            if (dataGrid.Columns[e.ColumnIndex].Name == "Prep Estimated Time")
            {
                string input = e.FormattedValue?.ToString().Trim();

                if (string.IsNullOrEmpty(input))
                    return;
                if (!TimeSpan.TryParse(input, out _))
                {
                    MessageBox.Show("Invalid iNptu");
                    e.Cancel = true;
                }
            }

            if (dataGrid.Columns[e.ColumnIndex].Name == "Size" || dataGrid.Columns[e.ColumnIndex].Name == "Flavor")
            {
                string input = e.FormattedValue?.ToString().Trim();

                if (string.IsNullOrEmpty(input))
                    return;

                if (!Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Invalid iNptu");
                    e.Cancel = true;
                }
            }
        }


        public List<MenuModel> getValues()
        {
            for (int i = 0; i < variants.Count; i++)
            {
                var row = table.Rows[i];

                string flavor = row[0]?.ToString();
                string size = row[1]?.ToString();
                TimeSpan time = TimeSpan.Parse(row[2]?.ToString());
                double price = double.Parse(row[3]?.ToString());

                variants[i] = MenuModel.Builder()
                    .WithMenuDetailId(variants[i].MenuDetailId)
                    .WithFlavorName(flavor)
                    .WithSizeName(size)
                    .WithEstimatedTime(time)
                    .WithPrice(price)
                    .Build();
            }

            return variants;
        }


    }
}
