using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.KioskApplication.Interface;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.KioskApplication.Services
{
    public class CartServices : ICalculateOrder
    {
        private IKioskMenuRepository _menuRepository;
        private FlowLayoutPanel flowCart;
        private List<MenuModel> orderList;
        public event EventHandler quantityChanged;

        private CouponModel coupon;
        public CartServices(IKioskMenuRepository _menuRepository, FlowLayoutPanel flowCart, List<MenuModel> orderList)
        {
            this._menuRepository = _menuRepository;
            this.flowCart = flowCart;
            this.orderList = orderList;
        }

        public void addMenuToCart(List<MenuModel> newOrders)
        {
            foreach (var menu in newOrders)
            {
                var exist = orderList.FirstOrDefault(o => o.MenuDetailId == menu.MenuDetailId && o.GetDiscountedPrice() == menu.GetDiscountedPrice() && o is MenuModel mp);

                if (exist != null)
                {
                    exist.PurchaseQty++;

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
                var order = orderList.FirstOrDefault(o => o.MenuDetailId == e.MenuDetailId);

                int b = _menuRepository.getMaxOrderRealTime(e.MenuDetailId, orderList);
                if (b <= 0)
                {
                    throw new MaxOrder("Unable to add more quantity.");
                }
                order.PurchaseQty++;
                cc.displayPurchasedMenu();

                quantityChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (MaxOrder ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deductQuantity(object sender, MenuModel e)
        {
            CartCard cc = sender as CartCard;
            var order = orderList.FirstOrDefault(o => o.MenuDetailId == e.MenuDetailId);
            order.PurchaseQty--;
            if (order.PurchaseQty == 0)
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
            return orderList.Sum(e => e.GetDiscountedPrice() * e.PurchaseQty);
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
