using System.Collections.Generic;
using Newtonsoft.Json;

namespace OrderingSystem.Model
{
    public class OrderModel
    {
        private string order_id;
        private double couponRate;
        public List<OrderItemModel> OrderItemList { get; set; }
        public List<MenuModel> OrderList { get; set; }
        public CouponModel Coupon { get; set; }

        public string OrderId { get => order_id; }
        public double CouponRate { get => couponRate; }


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


            public OrderBuilder SetOrderId(string c)
            {
                _order.order_id = c;
                return this;
            }
            public OrderBuilder SetOrderItemModel(List<OrderItemModel> c)
            {
                _order.OrderItemList = c;
                return this;
            }
            public OrderBuilder SetOrderList(List<MenuModel> c)
            {
                _order.OrderList = c;
                return this;
            }



            public OrderBuilder SetCoupon(CouponModel c)
            {
                _order.Coupon = c;
                return this;
            }
            public OrderBuilder SetCouponRate(double c)
            {
                _order.couponRate = c;
                return this;
            }


            public OrderModel Build()
            {
                return _order;
            }


        }


    }
}
