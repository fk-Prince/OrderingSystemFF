using System.Collections.Generic;
using Newtonsoft.Json;

namespace OrderingSystem.Model
{
    public class OrderModel
    {
        private string order_id;
        public List<OrderItemModel> OrderItemList { get; set; }
        public CouponModel Coupon { get; set; }

        public string OrderId { get => order_id; }
        public string JsonOrderList()
        {
            return JsonConvert.SerializeObject(OrderItemList);
        }

        public static OrderBuilder Builder() => new OrderBuilder();

        public class OrderBuilder
        {
            private OrderModel _order;

            public OrderBuilder()
            {
                _order = new OrderModel();
            }


            public OrderBuilder WithOrderId(string c)
            {
                _order.order_id = c;
                return this;
            }
            public OrderBuilder WithOrderItemList(List<OrderItemModel> c)
            {
                _order.OrderItemList = c;
                return this;
            }



            public OrderBuilder WithCoupon(CouponModel c)
            {
                _order.Coupon = c;
                return this;
            }


            public OrderModel Build()
            {
                return _order;
            }


        }


    }
}
