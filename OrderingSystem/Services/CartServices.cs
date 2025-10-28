using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.KioskApplication.Interface;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.KioskApplication.Services
{
    public class CartServices : ICalculateOrder
    {
        //private IKioskMenuRepository _menuRepository;
        private KioskMenuServices menuServices;
        private FlowLayoutPanel flowCart;
        private List<MenuModel> orderList;
        public event EventHandler quantityChanged;

        private CouponModel coupon;
        public CartServices(KioskMenuServices menuServices, FlowLayoutPanel flowCart, List<MenuModel> orderList)
        {
            this.menuServices = menuServices;
            this.flowCart = flowCart;
            this.orderList = orderList;
        }

        public void addMenuToCart(List<MenuModel> newOrders)
        {

            foreach (var menu in newOrders)
            {
                MenuModel mm = getOrder(menu);

                if (mm != null)
                {
                    mm.PurchaseQty++;

                    foreach (var i in flowCart.Controls.OfType<CartCard>())
                    {
                        i.displayPurchasedMenu();
                    }
                }
                else
                {
                    orderList.Add(menu);
                    addNewCart(menu);
                }
                quantityChanged?.Invoke(this, EventArgs.Empty);
            }

        }

        private void addQuantity(object sender, MenuModel e)
        {
            try
            {
                CartCard cc = sender as CartCard;
                MenuModel order = getOrder(e);
                int b = menuServices.getMaxOrderRealTime(e.MenuDetailId, orderList);

                if (b <= 0)
                    throw new MaxOrder("Unable to add more quantity.");

                order.PurchaseQty++;
                cc.displayPurchasedMenu();
                quantityChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (MaxOrder)
            {
                throw;
            }
        }
        public MenuModel getOrder(MenuModel e)
        {
            MenuModel order = null;
            if (order is MenuPackageModel)
                return order = orderList.FirstOrDefault(o => o.MenuDetailId == e.MenuDetailId && o.getPrice() == e.getPrice() && o is MenuPackageModel);
            else
                return order = orderList.FirstOrDefault(o => o.MenuDetailId == e.MenuDetailId && o.getPrice() == e.getPrice());
        }
        private void deductQuantity(object sender, MenuModel e)
        {
            CartCard cc = sender as CartCard;
            MenuModel order = getOrder(e);
            order.PurchaseQty--;
            if (order.PurchaseQty <= 0)
            {
                orderList.Remove(order);
                flowCart.Controls.Remove(cc);
            }
            cc.displayPurchasedMenu();
            quantityChanged?.Invoke(this, EventArgs.Empty);
        }


        public double calculateCoupon(CouponModel coupon)
        {

            if (coupon == null) return 0.00;
            this.coupon = coupon;
            double subtotal = calculateSubtotal();
            return coupon.CouponRate * subtotal;
        }

        public double calculateSubtotal()
        {
            return orderList.Sum(e => e.getPrice() * e.PurchaseQty);
        }

        public double calculateTotalAmount()
        {
            double subtotal = calculateSubtotal();
            double vat = calculateVat();
            double coupon = calculateCoupon(this.coupon);
            return (subtotal - coupon) + vat;
        }

        public double calculateVat()
        {
            double tax = 0.12;
            return tax * calculateSubtotal();
        }

        private void addNewCart(MenuModel menu)
        {

            CartCard cc = new CartCard(menu);
            cc.addQuantityEvent += addQuantity;
            cc.deductQuantityEvent += deductQuantity;
            cc.Margin = new Padding(10, 5, 5, 5);
            flowCart.Controls.Add(cc);
        }
    }
}