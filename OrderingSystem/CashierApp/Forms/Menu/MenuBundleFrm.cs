using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Components;
using OrderingSystem.Model;
using OrderingSystem.Properties;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository.CategoryRepository;
namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class MenuBundleFrm : Form
    {
        private List<MenuModel> inclded = new List<MenuModel>();
        private List<IngredientModel> ingredientSelected = new List<IngredientModel>();
        private IMenuRepository cashierMenuRepository;
        public MenuBundleFrm()
        {
            InitializeComponent();
            cashierMenuRepository = new MenuRepository();
        }


        private void newBundleEvent(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(menuName.Text.Trim()) ||
               string.IsNullOrEmpty(menuDescription.Text.Trim()) ||
               string.IsNullOrEmpty(menuPrice.Text.Trim()) ||
               string.IsNullOrEmpty(cmbCat.Text.Trim()) ||
               string.IsNullOrWhiteSpace(estimatedTime.Text.Trim()))
            {
                MessageBox.Show("Please fill all * fields.");
                return;
            }

            if (inclded.Count <= 1)
            {
                MessageBox.Show("It should atleast contain 2 Existing Menu.");
                return;
            }

            if (!isPriceValid(menuPrice.Text.Trim()))
            {
                MessageBox.Show("Invalid price .");
                return;
            }

            if (!TimeSpan.TryParse(estimatedTime.Text.Trim(), out TimeSpan est))
            {
                MessageBox.Show("Invalid estimated time format.");
                return;
            }

            string name = menuName.Text.Trim();

            if (cashierMenuRepository.isMenuNameExist(name))
            {
                MessageBox.Show("Menu Name already exists, try different.");
                return;
            }

            string desc = menuDescription.Text.Trim();
            double price = double.Parse(menuPrice.Text.Trim());
            string cat = cmbCat.Text.Trim();
            if (pictureBox.Image == null) pictureBox.Image = Resources.placeholder;
            byte[] image = ImageHelper.GetImageFromFile(pictureBox.Image);


            MenuPackageModel md = MenuPackageModel.Builder()
                .WithMenuName(name)
                .WithMenuDescription(desc)
                .WithPrice(price)
                .WithEstimatedTime(est)
                .WithMenuImageByte(image)
                .WithIngredients(ingredientSelected)
                .WithPackageIncluded(inclded)
                .WithCategoryName(cat)
                .Build();

            if (cashierMenuRepository.createBundleMenu(md))
            {
                MessageBox.Show("New menu created successfully.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to create new menu.");
            }
        }
        private bool isPriceValid(string text)
        {
            return Regex.IsMatch(menuPrice.Text.Trim(), @"^(\d{1,3}(,\d{3})*|\d+)(\.\d{1,2})?$");
        }
        private void ingredientListButton(object sender, EventArgs eb)
        {
            //IngredientPopup p = new IngredientPopup("Add Ingredient");
            //p.ingredientSelector(ingredientSelected);
            //p.initTable();
            //p.closeButton.Visible = true;
            //p.buttonClicked += (s, e) =>
            //{
            //    ingredientSelected = e;
            //};
            //DialogResult rs = p.ShowDialog(this);
            //if (rs == DialogResult.OK)
            //{
            //    ingredientButton.Text = ingredientSelected.Count > 0 ? "View selected ingredients" : "Click to choose ingredients";
            //    p.Hide();
            //}
        }
        private void menuListButton(object sender, System.EventArgs e)
        {
            BundleMenuPopup p = new BundleMenuPopup(inclded);

            DialogResult rs = p.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                inclded = p.getMenuSelected();
                menuButton.Text = inclded.Count > 0 ? "View included menu" : "Click to choose bundle menu";
                p.Hide();
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void MenuBundleFrm_Load(object sender, EventArgs e)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            List<CategoryModel> cat = categoryRepository.getCategories();
            cat.ForEach(ex => cmbCat.Items.Add(ex.CategoryName));
        }
    }
}
