using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Options;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication
{
    public partial class PopupOptions : Form
    {

        private IKioskMenuRepository _menuRepository;
        private IMenuOptions menuOptions;

        public event EventHandler<List<MenuModel>> orderListEvent;
        private List<MenuModel> orderList;


        public PopupOptions(IKioskMenuRepository _menuRepository, MenuModel menu)
        {
            InitializeComponent();
            this._menuRepository = _menuRepository;
            orderList = new List<MenuModel>();

            displayDetails(menu);
            HandleCreated += (s, e) => { init(menu); };
        }

        private void displayDetails(MenuModel menu)
        {
            image.Image = menu.Image;
            menuName.Text = menu.MenuName;
            description.Text = menu.MenuDescription;
        }

        private void init(MenuModel menu)
        {
            try
            {

                if (_menuRepository.isMenuPackage(menu))
                {
                    menuOptions = new PackageOption(_menuRepository, flowPanel);
                }
                else
                {
                    menuOptions = new RegularOption(_menuRepository, flowPanel);
                }

                if (menuOptions is IOutOfOrder e)
                {
                    e.outOfOrder += (ses, ese) =>
                    {
                        outofstock.Visible = true;
                        bb.Enabled = false;
                    };
                }
                menuOptions.menuOptions(menu);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error.");
            }
        }

        private void closePopup(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void confirmOrder(object sender, EventArgs e)
        {
            try
            {
                if (menuOptions != null)
                {
                    if (menuOptions is ISelectedFrequentlyOrdered freqOrdered)
                    {
                        var frequentlyOrdered = freqOrdered.getFrequentlyOrdered();
                        if (frequentlyOrdered != null)
                            orderList.AddRange(frequentlyOrdered);
                    }

                    var orders = menuOptions.confirmOrder();
                    if (orders == null || orders.Count == 0)
                        return;

                    orderList.AddRange(orders);
                    orderListEvent?.Invoke(this, orderList);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) when (ex is OutOfOrder || ex is NoSelectedMenu)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error");
            }
        }
    }
}