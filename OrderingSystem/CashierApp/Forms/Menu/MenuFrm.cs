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
        private IMenuRepository menuRepository;
        private IIngredientRepository ingredientRepository;
        private ICategoryRepository categoryRepository;
        private MenuService menuService;
        public MenuFrm()
        {
            InitializeComponent();
            menuRepository = new MenuRepository();
            menuService = new MenuService(menuRepository);
            ingredientRepository = new IngredientRepository();
            categoryRepository = new CategoryRepository();

            displayMenu();
        }
        private void displayMenu()
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
        private void hover(Control c, MenuModel i)
        {
            c.Click += (s, e) =>
            {
                MenuInformation mi = new MenuInformation(i, menuRepository, categoryRepository, ingredientRepository);
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
            MenuBundleFrm f = new MenuBundleFrm();
            DialogResult rs = f.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                f.Hide();
            }
        }
        public void showNewMenu()
        {
            NewMenu f = new NewMenu(menuService, ingredientRepository);
            DialogResult rs = f.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                f.Hide();
            }
        }


    }
}
