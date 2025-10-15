using System.Collections.Generic;
using Newtonsoft.Json;

namespace OrderingSystem.Model
{
    public class OrderModel
    {
        private string order_id;
        private string menu_name;
        private double totalPrice;
        private double price;
        private int quantity;
        private double couponRate;


        public List<MenuModel> OrderList { get; set; }
        public CouponModel Coupon { get; set; }

        public string Order_id { get => order_id; }
        public string Menu_name { get => menu_name; }
        public double TotalPrice { get => totalPrice; }
        public double PricePerQuantity { get => price; }
        public double CouponRate { get => couponRate; }
        public int Quantity { get => quantity; }


        public string JsonOrderList()
        {
            return JsonConvert.SerializeObject(OrderList);
        }

        public static OrderBuilder Builder() => new OrderBuilder();

        public class OrderBuilder
        {
            private OrderModel _order;

            public OrderBuilder()
            {
                _order = new OrderModel();
            }

            public OrderBuilder SetOrderList(List<MenuModel> list)
            {
                _order.OrderList = list;
                return this;
            }
            public OrderBuilder SetCoupon(CouponModel c)
            {
                _order.Coupon = c;
                return this;
            }
            public OrderBuilder SetOrderId(string c)
            {
                _order.order_id = c;
                return this;
            }
            public OrderBuilder SetMenuName(string c)
            {
                _order.menu_name = c;
                return this;
            }
            public OrderBuilder SetTotalPrice(double c)
            {
                _order.totalPrice = c;
                return this;
            }
            public OrderBuilder SetPricePerQuantity(double c)
            {
                _order.price = c;
                return this;
            }
            public OrderBuilder SetCouponRate(double c)
            {
                _order.couponRate = c;
                return this;
            }
            public OrderBuilder SetQuantity(int c)
            {
                _order.quantity = c;
                return this;
            }

            public OrderModel Build()
            {
                return _order;
            }


        }


    }
}
