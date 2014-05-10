﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace OrderMatchingEngine
{
    public class OrderBook
    {
        private Int64 productId;

        private Dictionary<Int64, Order> allOrders = new Dictionary<Int64, Order>();

        private Dictionary<Int64, List<Order>> ordersByTrader = new Dictionary<Int64, List<Order>>();
        
        private LinkedList<Order> buyQueue = new LinkedList<Order>();

        private LinkedList<Order> sellQueue = new LinkedList<Order>();

        public OrderBook( Int64 productId )
        {
            this.productId = productId;
            this.buyQueue = new LinkedList<Order>();
            this.sellQueue = new LinkedList<Order>();
        }

        public void addOrder(Order order)
        {
            order.orderNumber = OrderNumberGenerator.getNext();
            order.submitTime = DateTime.Now;
            (order.buySell == BuySell.Buy ? buyQueue : sellQueue).AddLast(order);

            allOrders.Add(order.orderNumber, order);

            List<Order> orders;
            if (ordersByTrader.TryGetValue(order.traderId, out orders))
            {
                orders.Add(order);
            }
            else
            {
                orders = new List<Order>();
                orders.Add(order);
                ordersByTrader.Add(order.traderId, orders);
            }

        }

        public List<Order> getOrders(Int64 traderId)
        {
            List<Order> orders;
            if (ordersByTrader.TryGetValue(traderId, out orders))
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
