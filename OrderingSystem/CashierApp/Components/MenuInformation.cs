using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.Menu;
using OrderingSystem.CashierApp.Table;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Repository.Ingredients;

namespace OrderingSystem.CashierApp.Components
{
    public partial class MenuInformation : Form
    {
        private readonly IMenuRepository menuRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IIngredientRepository ingredientRepository;
        private List<MenuModel> variantList;
        private List<MenuModel> included;

        private readonly MenuModel menu;
        private RegularTable regular;
        private PackageTable package;
        private bool isEditMode = false;
        private bool isPackaged = false;
        public event EventHandler menuUpdated;
        public MenuInformation(MenuModel menu, IMenuRepository menuRepository, ICategoryRepository categoryRepository, IIngredientRepository ingredientRepository)
        {
            InitializeComponent();
            this.menu = menu;
            this.menuRepository = menuRepository;
            this.categoryRepository = categoryRepository;
            this.ingredientRepository = ingredientRepository;
            displayMenuDetails();
            displayTable();
        }
        private void displayMenuDetails()
        {
            image.Image = menu.MenuImage;
            menuName.Text = menu.MenuName;
            description.Text = menu.MenuDescription;
            catTxt.Text = menu.CategoryName;


            List<CategoryModel> ca = categoryRepository.getCategories();
            ca.ForEach(e => category.Items.Add(e.CategoryName));
            category.SelectedItem = menu.CategoryName;
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
            isPackaged = menuRepository.isMenuPackage(menu);
            if (isPackaged)
            {
                b2.Visible = false;
                included = menuRepository.getBundled(menu);
                loadForm(package = new PackageTable(included, menuRepository));
                package.dataGrid.Enabled = false;
                lPrice.Visible = true;
                price.Visible = true;
                price.Text = menuRepository.getBundlePrice(menu).ToString("N2");
            }
            else
            {
                b3.Visible = false;
                variantList = menuRepository.getMenuDetail().FindAll(e => e.MenuId == menu.MenuId);
                loadForm(regular = new RegularTable(variantList, ingredientRepository));
                regular.dataGrid.Enabled = false;
            }
        }
        private void changeMode(object sender, EventArgs e)
        {
            isEditMode = !isEditMode;
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
            if (package != null) package.dataGrid.Enabled = isEditMode;
            if (regular != null) regular.dataGrid.Enabled = isEditMode;
            category.SelectedItem = menu.CategoryName;
        }
        private void confirmEdit()
        {
            string name = menuName.Text.Trim();
            string cat = category.Text.Trim();
            string desc = description.Text.Trim();
            string pricex = price.Text.Trim();
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

            if (package != null)
            {
                var builder = MenuPackageModel.Builder()
                                 .WithMenuId(menu.MenuId)
                                 .WithMenuName(name)
                                 .WithMenuDescription(desc)
                                 .WithCategoryName(cat)
                                 .WithPrice(double.Parse(pricex))
                                 .WithPackageIncluded(package.getMenus());
                if (imagex != null) builder = builder.WithMenuImageByte(imagex);
                MenuPackageModel menus = builder.Build();
                suc = menuRepository.updatePackageMenu(menus);
            }
            else if (regular != null)
            {
                var builder = MenuModel.Builder()
                             .WithMenuId(menu.MenuId)
                             .WithMenuName(name)
                             .WithMenuDescription(desc)
                             .WithCategoryName(cat)
                             .WithVariant(regular.getValues());

                if (imagex != null) builder = builder.WithMenuImageByte(imagex);

                MenuModel menus = builder.Build();
                suc = menuRepository.updateRegularMenu(menus);
            }

            if (suc)
            {
                MessageBox.Show("Updated Successfully");
                menuUpdated.Invoke(this, EventArgs.Empty);
            }
            else MessageBox.Show("Failed to update");
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
            VariantMenuPopup pop = new VariantMenuPopup(cloneList, ingredientRepository);
            DialogResult rs = pop.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                cloneList = pop.getVariants();
                var difference = cloneList.Except(variantList).ToList();
                menuRepository.newMenuVariant(menu.MenuId, difference);
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
            IngredientMenu pop = new IngredientMenu(ingredientRepository);
            pop.IngredientSelectedEvent += (ss, ee) =>
            {
                List<IngredientModel> ingredientSelected = ee;
                if (ingredientSelected.Count > 0)
                {

                    bool suc = ingredientRepository.saveIngredientByMenu(menu.MenuId, ingredientSelected, "Package");
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
    }
}
