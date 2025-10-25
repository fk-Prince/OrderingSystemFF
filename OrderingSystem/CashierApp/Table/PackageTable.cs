using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Table
{
    public partial class PackageTable : Form
    {
        private DataTable table;
        private List<MenuModel> included;
        private List<MenuModel> menuS;

        public List<MenuModel> getMenus()
        {
            menuS = new List<MenuModel>();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                string menuName = row.Cells["Menu Name"]?.Value?.ToString();
                string quantityStr = row.Cells["Quantity"]?.Value?.ToString();
                object fixedObj = row.Cells["Fixed ✓"]?.Value;

                if (string.IsNullOrWhiteSpace(menuName)) continue;

                if (!int.TryParse(quantityStr, out int quantity))
                {
                    MessageBox.Show($"Invalid quantity for '{menuName}'", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                bool isFixed = fixedObj != null && Convert.ToBoolean(fixedObj);

                var selectedMenu = included.Find(x => x.MenuName == menuName);
                if (selectedMenu == null) continue;

                MenuPackageModel p = MenuPackageModel.Builder()
                    .WithMenuDetailId(selectedMenu.MenuDetailId)
                    .WithPackageId((selectedMenu as MenuPackageModel)?.PackageId ?? 0)
                    .WithMenuName(menuName)
                    .WithQuantity(quantity)
                    .isFixed(isFixed)
                    .Build();
                menuS.Add(p);
            }

            return menuS;
        }
        public PackageTable(List<MenuModel> included)
        {
            InitializeComponent();
            this.included = included;
            displayPackage();
        }

        public void displayPackage()
        {
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            table = new DataTable();
            table.Columns.Add("Menu Name");
            table.Columns.Add("Quantity");
            table.Columns.Add("Fixed ✓", typeof(bool));
            dataGrid.DataSource = table;

            DataGridViewCheckBoxColumn fx = new DataGridViewCheckBoxColumn();
            fx.DataPropertyName = "Fixed ✓";
            fx.HeaderText = "Fixed ✓";

            foreach (var m in included)
            {
                if (m is MenuPackageModel v)
                {
                    table.Rows.Add(v.MenuName, v.Quantity, v.isFixed);
                }
            }
        }


        private void dataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //foreach (DataGridViewRow row in dataGrid.Rows)
            //{
            //    bool isChecked = false;
            //    if (row.Cells[0].Value != null && bool.TryParse(row.Cells[0].Value.ToString(), out bool isC))
            //    {
            //        isChecked = isC;
            //    }

            //    if (isChecked)
            //    {
            //        if (!int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int r))
            //        {
            //            MessageBox.Show("No quantity");
            //            return;
            //        }
            //        string menuName = row.Cells["Menu Name"].Value?.ToString();
            //        string flavor = row.Cells["Flavor"].Value?.ToString();
            //        string size = row.Cells["Size"].Value?.ToString();
            //        bool fx = bool.Parse(row.Cells["Fixed ✓"].Value.ToString());
            //        int q = int.Parse(row.Cells["Quantity"].Value?.ToString());

            //        MenuPackageModel selectedMenu = (MenuPackageModel)included.Find(x => x.MenuName == menuName && x.FlavorName == flavor && x.SizeName == size);

            //        MenuPackageModel p = MenuPackageModel.Builder()
            //            .WithMenuDetailId(selectedMenu.MenuDetailId)
            //            .WithPackageId(selectedMenu.PackageId)
            //            .WithMenuName(menuName)
            //            .WithSizeName(size)
            //            .WithFlavorName(flavor)
            //            .WithQuantity(q)
            //            .isFixed(fx)
            //            .Build();

            //        menuS.Add(p);
            //    }
            //}
            //DialogResult = DialogResult.OK;
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
