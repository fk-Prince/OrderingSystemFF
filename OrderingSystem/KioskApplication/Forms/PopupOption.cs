using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Options;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.KioskApplication
{
    public partial class PopupOption : Form
    {
        public MenuModel menu { get; }
        public IKioskMenuRepository _menuRepository;
        public event EventHandler<List<MenuModel>> orderListEvent;
        private List<MenuModel> orderList;
        private IMenuOptions menuOptions;


        public PopupOption(IKioskMenuRepository _menuRepository, MenuModel menu, List<MenuModel> orderList)
        {
            InitializeComponent();
            this._menuRepository = _menuRepository;
            this.menu = menu;
            this.orderList = orderList;

            displayDetails(menu);
            diisplayOptions();
        }
        private void diisplayOptions()
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
                        //outofstock.Visible = true;
                        bb.Enabled = false;
                    };
                }
                menuOptions.displayMenuOptions(menu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error. " + ex.Message);
            }
        }
        private void displayDetails(MenuModel menu)
        {
            image.Image = menu.MenuImage;
            menuName.Text = menu.MenuName;
            description.Text = menu.MenuDescription;
        }
        private void addToOrder(object sender, System.EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error " + ex.Message);
            }
        }
        private void close(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
