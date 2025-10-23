﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using OrderingSystem.CashierApp.Forms.Menu;
using OrderingSystem.CashierApp.Table;
using OrderingSystem.Model;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Components
{
    public partial class MenuInformation : Form
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IngredientServices ingredientServices;
        private List<MenuModel> variantList;
        private List<MenuModel> included;
        private MenuService menuService;

        private readonly MenuModel menu;
        private RegularTable regular;
        private PackageTable package;
        private bool isEditMode = false;
        private bool isPackaged = false;
        public event EventHandler menuUpdated;
        private StaffModel userStaff;
        public MenuInformation(MenuModel menu, MenuService menuService, ICategoryRepository categoryRepository, IngredientServices ingredientServices, StaffModel userStaff)
        {
            InitializeComponent();
            this.menu = menu;
            this.menuService = menuService;
            this.categoryRepository = categoryRepository;
            this.ingredientServices = ingredientServices;
            this.userStaff = userStaff;
            displayMenuDetails();
            displayTable();
        }
        private void displayMenuDetails()
        {
            image.Image = menu.MenuImage;
            menuName.Text = menu.MenuName;
            description.Text = menu.MenuDescription;
            catTxt.Text = menu.CategoryName;
            category.Text = menu.CategoryName;
            toggle.CheckedChanged -= guna2ToggleSwitch1_CheckedChanged;
            toggle.Checked = menu.isAvailable;
            toggle.CheckedChanged += guna2ToggleSwitch1_CheckedChanged;
            if (userStaff.Role.ToLower() == "cashier")
            {
                b1.Visible = false;
                b2.Visible = false;
                b3.Visible = false;
                b4.Visible = false;
            }
            isAvailable();
            try
            {
                List<CategoryModel> ca = categoryRepository.getCategories();
                ca.ForEach(e => category.Items.Add(e.CategoryName));
                category.SelectedItem = menu.CategoryName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadForm(Form f)
        {
            if (mm.Controls.Count > 0)
            {
                mm.Controls.Clear();
            }

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mm.Controls.Add(f);
            f.Show();
        }
        private void displayTable()
        {
            try
            {
                isPackaged = menuService.isMenuPackage(menu);
                if (isPackaged)
                {
                    b2.Visible = false;
                    b4.Visible = true;
                    included = menuService.getBundled(menu);
                    loadForm(package = new PackageTable(included));

                    lPrice.Visible = true;
                    price.Visible = true;
                    price.Text = menuService.getBundlePrice(menu).ToString("N2");
                }
                else
                {
                    b3.Visible = false;
                    variantList = menuService.getMenuDetail().FindAll(e => e.MenuId == menu.MenuId);
                    loadForm(regular = new RegularTable(variantList, ingredientServices));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error" + ex.Message);
                Console.WriteLine(ex.Message + "displayTable ON menuinfroamtion");
            }
        }
        private void changeMode(object sender, EventArgs e)
        {
            isEditMode = !isEditMode;
            b1.Text = isEditMode ? "Save" : "Edit";
            if (isEditMode)
            {
                catTxt.Visible = false;
                category.Visible = true;
                Border(true);
            }
            else
            {
                confirmEdit();
                catTxt.Visible = true;
                Border(false);
            }
            toggle.Enabled = isEditMode;
            category.Text = menu.CategoryName;
            catTxt.Text = menu.CategoryName;
        }
        private void confirmEdit()
        {
            try
            {
                string name = menuName.Text.Trim();
                string cat = category.Text.Trim();
                string desc = description.Text.Trim();
                string pricex = price.Text.Trim();

                DialogResult rs = MessageBox.Show("Do you want to proceed to update this menu?", "Update", MessageBoxButtons.YesNo);
                if (rs == DialogResult.No)
                {
                    return;
                }

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(cat) || (isPackaged && string.IsNullOrEmpty(pricex)))
                {
                    MessageBox.Show("Emty Field");
                    return;
                }
                if (!isPriceValid(pricex) && isPackaged)
                {
                    MessageBox.Show("Invalid price");
                    return;
                }

                byte[] imagex = null;
                if (image.ImageLocation != null)
                    imagex = ImageHelper.GetImageFromFile(image.Image);

                bool suc = false;
                MenuModel menus = null;
                string type = "";
                if (package != null)
                {
                    if (package.getMenus() == null) return;

                    var builder = MenuPackageModel.Builder()
                                     .WithMenuId(menu.MenuId)
                                     .WithMenuName(name)
                                     .isAvailable(toggle.Checked)
                                     .WithMenuDescription(desc)
                                     .WithCategoryName(cat)
                                     .WithPrice(double.Parse(pricex))
                                     .WithPackageIncluded(package.getMenus());
                    if (imagex != null) builder = builder.WithMenuImageByte(imagex);
                    menus = builder.Build();
                    type = "bundle";
                }
                else if (regular != null)
                {
                    if (regular.getMenus() == null) return;
                    var builder = MenuModel.Builder()
                                 .WithMenuId(menu.MenuId)
                                 .WithMenuName(name)
                                 .isAvailable(toggle.Checked)
                                 .WithMenuDescription(desc)
                                 .WithCategoryName(cat)
                                 .WithVariant(regular.getMenus());
                    if (imagex != null) builder = builder.WithMenuImageByte(imagex);

                    string json = JsonConvert.SerializeObject(regular.getMenus());
                    Console.WriteLine(json);
                    menus = builder.Build();
                    type = "regular";
                }

                suc = menuService.updateMenu(menus, type);

                if (suc)
                {
                    MessageBox.Show("Updated Successfully");
                    menuUpdated.Invoke(this, EventArgs.Empty);
                }
                else MessageBox.Show("Failed to update");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error." + ex.Message);
            }
        }
        private void Border(bool x)
        {
            foreach (var xb in Controls)
            {
                if (xb is Guna2TextBox tb)
                {
                    tb.ReadOnly = !x;
                    tb.Enabled = x;
                    tb.BorderThickness = x ? 1 : 0;
                }
            }
        }
        private bool isPriceValid(string text)
        {
            return Regex.IsMatch(text, @"^(\d{1,3}(,\d{3})*|\d+)(\.\d{1,2})?$");
        }
        private void ImageButton(object sender, EventArgs e)
        {
            ofd.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                image.ImageLocation = imagePath;
            }
            else
            {
                image.ImageLocation = null;
                image.Image = menu.MenuImage;
            }
        }
        private void newVariantButton(object sender, EventArgs e)
        {
            var cloneList = new List<MenuModel>(variantList);
            VariantMenuPopup pop = new VariantMenuPopup(cloneList, ingredientServices);
            DialogResult rs = pop.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                cloneList = pop.getVariants();
                var difference = cloneList.Except(variantList).ToList();
                menuService.newMenuVariant(menu.MenuId, difference);
                variantList.AddRange(difference);
                displayTable();
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BundleMenuPopup bb = new BundleMenuPopup(included);
            DialogResult rs = bb.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                included = bb.getMenuSelected();
                displayTable();
                bb.Hide();
            }
        }
        private void b4_Click(object sender, EventArgs e)
        {
            IngredientMenu pop = new IngredientMenu(ingredientServices);
            pop.IngredientSelectedEvent += (ss, ee) =>
            {
                List<IngredientModel> ingredientSelected = ee;
                if (ingredientSelected.Count > 0)
                {

                    bool suc = ingredientServices.saveIngredientByMenu(menu.MenuId, ingredientSelected, "Package");
                    if (suc)
                    {
                        MessageBox.Show("Ingredient Updated.");
                        pop.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ingredient ex.");
                    }
                }
            };
            pop.confirmButton.Enabled = true;
            pop.getIngredientByMenu(menu);
            pop.initTable2();
            DialogResult rs = pop.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                pop.Hide();
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            toggle.CheckedChanged -= guna2ToggleSwitch1_CheckedChanged;
            DialogResult rs = MessageBox.Show($"Are you sure you want to {(!toggle.Checked ? "disable" : "enable")} this menu?", "Confirm Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                toggle.Checked = toggle.Checked;
            }
            else
            {
                toggle.Checked = !toggle.Checked;
            }
            toggle.CheckedChanged += guna2ToggleSwitch1_CheckedChanged;

            isAvailable();
        }

        private void isAvailable()
        {
            if (toggle.Checked || !isEditMode)
            {
                BackColor = Color.White;
                if (package != null) package.BackColor = Color.White;
                if (regular != null) regular.BackColor = Color.White;
            }
            else
            {
                if (package != null) package.BackColor = Color.LightGray;
                if (regular != null) regular.BackColor = Color.LightGray;
                BackColor = Color.LightGray;
            }
        }
    }
}
