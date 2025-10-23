﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Components;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class VariantMenuPopup : Form
    {

        private List<IngredientModel> ingredientSelected;
        private readonly List<MenuModel> variantList;
        private readonly IngredientServices ingredientServices;

        public VariantMenuPopup(List<MenuModel> variantList, IngredientServices ingredientServices)
        {
            InitializeComponent();
            this.variantList = variantList;
            this.ingredientServices = ingredientServices;
            ingredientSelected = new List<IngredientModel>();

            displayIngredient();
        }

        private bool isPriceValid(string text)
        {
            return Regex.IsMatch(menuPrice.Text.Trim(), @"^(\d{1,3}(,\d{3})*|\d+)(\.\d{1,2})?$");
        }
        private void confirmButton()
        {
            if (!isPriceValid(menuPrice.Text.Trim()))
            {
                MessageBox.Show("Invalid price .");
                return;
            }
            string flavor = cmbFlavor.Text.Trim();
            string size = cmbSize.Text.Trim();
            if (flavor == "") flavor = "Regular";
            if (size == "") size = "Regular";
            flavor = flavor.Substring(0, 1).ToUpper() + flavor.Substring(1).ToLower();
            size = size.Substring(0, 1).ToUpper() + size.Substring(1).ToLower();

            bool exist = variantList.Any(ee =>
                 string.Equals(ee.FlavorName, flavor, StringComparison.OrdinalIgnoreCase) &&
                 string.Equals(ee.SizeName, size, StringComparison.OrdinalIgnoreCase));
            if (exist)
            {
                MessageBox.Show($"This pair of Size: {size} & Flavor: {flavor}, is already exists");
                return;
            }
            if (!TimeSpan.TryParse(estimatedTime.Text.Trim(), out TimeSpan ex))
            {
                MessageBox.Show("Invalid Time Format.");
                return;
            }

            if (ingredientSelected.Count <= 0)
            {
                MessageBox.Show("No Selected Ingredient");
                return;
            }

            MenuModel variant = MenuModel.Builder()
                .WithPrice(double.Parse(menuPrice.Text.Trim()))
                .WithFlavorName(flavor)
                .WithEstimatedTime(TimeSpan.Parse(estimatedTime.Text.Trim()))
                .WithSizeName(size)
                .WithIngredients(ingredientSelected.ToList())
                .Build();
            variantList.Add(variant);

            MessageBox.Show("Successfully Added");
            ingredientSelected.Clear();
        }
        public List<MenuModel> getVariants()
        {
            return variantList;
        }
        private void exit(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        private void VariantMenuPopup_Load(object sender, EventArgs e)
        {
            try
            {
                MenuRepository menuRepository = new MenuRepository();
                List<string> flavor = menuRepository.getFlavor();
                List<string> size = menuRepository.getSize();
                flavor.ForEach(f => cmbFlavor.Items.Add(f));
                size.ForEach(f => cmbSize.Items.Add(f));
                if (flavor.Count > 0) cmbFlavor.SelectedIndex = 0;
                if (size.Count > 0) cmbSize.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
        public void displayIngredient()
        {
            if (mm.Controls.Count > 0)
            {
                mm.Controls.RemoveAt(0);
            }

            IngredientMenu im = new IngredientMenu(ingredientServices);
            im.getIngredient();
            im.initTable2();
            im.confirmButton.Visible = true;
            im.IngredientSelectedEvent += (s, e) =>
            {
                ingredientSelected = e;
                confirmButton();
                im.reset();
            };
            im.TopLevel = false;
            im.Dock = DockStyle.Fill;
            mm.Controls.Add(im);
            im.Show();
        }
    }
}
