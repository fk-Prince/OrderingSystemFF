using OrderingSystem.Model;

namespace OrderingSystem.Repository
{
    public interface IOrderRepository
    {
        bool getOrderAvailable(string order_id);
        bool getOrderExists(string order_id);
        OrderModel getOrders(string order_id);
        bool isOrderPayed(string order_id);
        bool saveNewOrder(OrderModel order);
        bool payOrder(string order_id, int staff_id, string payment_method);
        string getOrderId();
    }
}
