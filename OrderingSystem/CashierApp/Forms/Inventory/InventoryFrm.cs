using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class InventoryFrm : Form
    {

        private DataView view;
        private InventoryServices inventoryServices;
        public InventoryFrm(InventoryServices inventoryServices)
        {
            InitializeComponent();
            this.inventoryServices = inventoryServices;
            cb.SelectedIndex = 0;
            cb_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void txt_TextChanged(object sender, System.EventArgs e)
        {
            string s = cb.Text;
            if (s == "Track Quantity In/Out")
            {
                string staffFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Staff Incharge] LIKE '%{txt.Text}%'";
                string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
                string dateFilter = $"[Date-Action] >= #{dtFrom.Value:yyyy-MM-dd}# AND [Date-Action] <= #{dtTo.Value:yyyy-MM-dd}#";
                string staff_ingredient_filter = string.Join(" OR ", new[] { staffFilter, ingredientFilter }.Where(f => !string.IsNullOrEmpty(f)));
                string finalFilter = string.IsNullOrEmpty(staff_ingredient_filter) ? dateFilter : $"({staff_ingredient_filter}) AND {dateFilter}";
                view.RowFilter = finalFilter;
            }
            else if (s == "Expiry Tracking")
            {
                string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
                string dateFilter = $"[Expiry Date] >= #{dtFrom.Value:yyyy-MM-dd}# AND [Expiry Date] <= #{dtTo.Value:yyyy-MM-dd}#";
                string finalFilter = string.Join(" OR ", new[] { ingredientFilter, dateFilter }.Where(f => !string.IsNullOrEmpty(f)));
                view.RowFilter = finalFilter;
            }
            else if (s == "Inventory Reports")
            {
                string staffFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Staff Incharge] LIKE '%{txt.Text}%'";
                string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
                string dateFilter = $"[IN - Recorded At] >= #{dtFrom.Value:yyyy-MM-dd}# AND [IN - Recorded At] <= #{dtTo.Value:yyyy-MM-dd}#";
                string staff_ingredient_filter = string.Join(" OR ", new[] { staffFilter, ingredientFilter }.Where(f => !string.IsNullOrEmpty(f)));
                string finalFilter = string.IsNullOrEmpty(staff_ingredient_filter) ? dateFilter : $"({staff_ingredient_filter}) AND {dateFilter}";
                view.RowFilter = finalFilter;
            }
            else if (s == "Ingredient Usage")
            {
                string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
                view.RowFilter = ingredientFilter;
            }
            else if (s == "Menu Popular's")
            {
                string menuFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Menu Name] LIKE '%{txt.Text}%'";
                view.RowFilter = menuFilter;
            }
            else if (s == "Menu Performance")
            {
                string menuFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Menu Name] LIKE '%{txt.Text}%'";
                string sizeFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Size] LIKE '%{txt.Text}%'";
                string flavorFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Flavor] LIKE '%{txt.Text}%'";
                string priceFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Price] LIKE '%{txt.Text}%'";
                string finalFilter = string.Join(" OR ", new[] { menuFilter, sizeFilter, flavorFilter, priceFilter }.Where(f => !string.IsNullOrEmpty(f)));
                view.RowFilter = finalFilter;
            }
            dataGrid.Refresh();
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == -1) return;
            string s = cb.Text;

            if (s == "Track Quantity In/Out")
            {
                txt.PlaceholderText = "Search Staff, Ingredient";
                view = inventoryServices.getTrackingIngredients();
            }
            else if (s == "Expiry Tracking")
            {
                txt.PlaceholderText = "Search Ingredient";
                view = inventoryServices.getIngredientExpiry();
            }
            else if (s == "Inventory Reports")
            {
                txt.PlaceholderText = "Search Staff, Ingredient";
                view = inventoryServices.getInventorySummaryReports();
            }
            else if (s == "Ingredient Usage")
            {
                txt.PlaceholderText = "Search Ingredient";
                view = inventoryServices.getIngredientsUsage();
            }
            else if (s == "Menu Popular's")
            {
                txt.PlaceholderText = "Search Menu";
                view = inventoryServices.getMenuPopularity();
            }
            else if (s == "Menu Performance")
            {
                txt.PlaceholderText = "Search Menu, Flavor, Size, Price";
                view = inventoryServices.getMenuPerformance();
            }
            dataGrid.DataSource = view;
            dataGrid.Refresh();
            txt_TextChanged(this, EventArgs.Empty);
        }


        private void dtTo_ValueChanged(object sender, System.EventArgs e)
        {
            txt_TextChanged(this, EventArgs.Empty);
        }

        private void dtFrom_ValueChanged(object sender, System.EventArgs e)
        {
            txt_TextChanged(this, EventArgs.Empty);
        }
    }
}
