using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace OrderMatchingEngine
{
    public class OrderBook
    {
        private Dictionary<Int64, Order> allOrders = new Dictionary<Int64, Order>();

        private Dictionary<Tuple<Int64, Int64>, List<Order>> ordersByTraderProduct = new Dictionary<Tuple<Int64, Int64>, List<Order>>();
        
        public void addOrder(Order order)
        {
            order.orderNumber = OrderNumberGenerator.getNext();
            order.submitTime = DateTime.Now;

            allOrders.Add(order.orderNumber, order);

            Tuple<Int64, Int64> tuple = new Tuple<Int64, Int64>(order.traderId, order.productId);

            List<Order> orders;
            if (ordersByTraderProduct.TryGetValue(tuple, out orders))
            {
                orders.Add(order);
            }
            else
            {
                orders = new List<Order>();
                orders.Add(order);
                ordersByTraderProduct.Add(tuple, orders);
            }

        }

        public List<Order> getOrders(Tuple<Int64, Int64> tuple)
        {
            List<Order> orders;
            if (ordersByTraderProduct.TryGetValue(tuple, out orders))
            {
                return orders;
            }
            return new List<Order>();
        }

        public Boolean cancelOrder(Int64 orderId)
        {
            Order order;
            if (allOrders.TryGetValue(orderId, out order) && !order.matched)
            {
                order.cancelled = true;
                return true;
            }
            return false;
        }

    }
}
