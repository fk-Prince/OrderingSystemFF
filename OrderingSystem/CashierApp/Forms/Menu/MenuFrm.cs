using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Components;
using OrderingSystem.CashierApp.Forms.Menu;
using OrderingSystem.Model;
using OrderingSystem.Repo.CashierMenuRepository;
using OrderingSystem.Repository.CategoryRepository;
using OrderingSystem.Repository.Ingredients;
using OrderingSystem.Services;
//using OrderingSystem.Repo.CashierMenuRepository;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class MenuFrm : Form
    {

        private readonly IngredientServices ingredientServices;
        private readonly ICategoryRepository categoryRepository;
        private readonly MenuService menuService;
        private readonly StaffModel staff;
        public MenuFrm(StaffModel staff)
        {
            InitializeComponent();
            this.staff = staff;

            menuService = new MenuService(new MenuRepository());
            ingredientServices = new IngredientServices(new IngredientRepository());
            categoryRepository = new CategoryRepository();

            displayMenu();
        }
        private void displayMenu()
        {
            try
            {
                flowMenu.Controls.Clear();
                List<MenuModel> list = menuService.getMenus();
                foreach (var i in list)
                {

                    MenuCard m = new MenuCard(i);
                    m.Margin = new Padding(10, 10, 10, 10);
                    m.Tag = i;
                    flowMenu.Controls.Add(m);
                    hover(m, i);
                }
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }
        private void hover(Control c, MenuModel i)
        {
            c.Click += (s, e) =>
            {
                MenuInformation mi = new MenuInformation(i, menuService, categoryRepository, ingredientServices, staff);
                mi.menuUpdated += (ss, ee) => displayMenu();
                DialogResult rs = mi.ShowDialog(this);
                if (rs == DialogResult.OK)
                {
                    mi.Hide();
                }
            };

            foreach (Control cv in c.Controls)
            {
                hover(cv, i);
            }
        }
        public void showBundle()
        {
            MenuBundleFrm f = new MenuBundleFrm(menuService, ingredientServices);
            DialogResult rs = f.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                f.Hide();
            }
        }
        public void showNewMenu()
        {
            NewMenu f = new NewMenu(menuService, ingredientServices);
            DialogResult rs = f.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                f.Hide();
            }
        }


    }
}
