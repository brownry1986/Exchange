using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ClassLibrary;
using System.Runtime.Remoting.Messaging;
using System.Collections.Concurrent;

namespace OrderMatchingEngine
{
    class Matcher
    {
        BlockingCollection<Order> orderQueue;

        BlockingCollection<Trade> tradeQueue;

        Dictionary<decimal, List<Order>> buyQueue = new Dictionary<decimal, List<Order>>();

        Dictionary<decimal, List<Order>> sellQueue = new Dictionary<decimal, List<Order>>();

        public Matcher(BlockingCollection<Order> orderQueue, BlockingCollection<Trade> tradeQueue)
        {
            this.orderQueue = orderQueue;
            this.tradeQueue = tradeQueue;
        }

        public void Match()
        {
            while (true)
            {
                Order order = orderQueue.Take();
                Console.WriteLine("Matcher got order: {0}", order.ToString());
                decimal price = order.price;
                Int64 quantity = order.quantity;

                if (order.buySell == BuySell.Buy)
                {
                    if (sellQueue.Keys.Count > 0 && price > sellQueue.Keys.Min())
                    {
                        MatchOrders(sellQueue, order, sellQueue.Keys.Min());
                    }

                    if (order.quantity > order.filledQuantity)
                    {
                        AddOrder(price, order, buyQueue);
                    }
                }
                else
                {
                    if (buyQueue.Keys.Count > 0 && price < buyQueue.Keys.Max())
                    {
                        MatchOrders(buyQueue, order, buyQueue.Keys.Max());
                    }

                    if (order.quantity > order.filledQuantity)
                    {
                        AddOrder(price, order, sellQueue);
                    }
                }
            }
        }

        public void AddOrder(decimal price, Order order, Dictionary<decimal, List<Order>> orderQueue)
        {
            List<Order> openOrders = new List<Order>();
            if (orderQueue.TryGetValue(price, out openOrders))
            {
                openOrders.Add(order);
            }
            else
            {
                openOrders = new List<Order>();
                openOrders.Add(order);
                orderQueue.Add(price, openOrders);
            }

        }

        public void MatchOrders(Dictionary<decimal, List<Order>> queue, Order order, decimal price)
        {
            List<Order> orders = new List<Order>();
            if (queue.TryGetValue(price, out orders))
            {
                if (order.quantity == (orders[0].quantity - orders[0].filledQuantity))
                {
                    Console.WriteLine("New Order and Existing Order are FULLY MATCHED");
                    orders[0].filledQuantity += order.quantity;
                    order.filledQuantity = order.quantity;

                    // Create trades
                    Trade trade1 = new Trade();
                    trade1.tradeId = TradeNumberGenerator.getNext();
                    trade1.traderId = order.traderId;
                    trade1.productId = order.productId;
                    trade1.buySell = order.buySell;
                    trade1.quantity = order.quantity;
                    trade1.executionPrice = order.price;
                    trade1.originalOrderId = order.orderNumber;
                    trade1.oppositeOrderId = orders[0].orderNumber;
                    trade1.executionTime = DateTime.Now;
                    trade1.feeAmount = order.price * Convert.ToDecimal(order.quantity) * Convert.ToDecimal(.001);
                    Console.WriteLine("Trade Create: {0}", trade1.ToString());

                    Trade trade2 = new Trade();
                    trade2.tradeId = TradeNumberGenerator.getNext();
                    trade2.traderId = orders[0].traderId;
                    trade2.productId = orders[0].productId;
                    trade2.buySell = orders[0].buySell;
                    trade2.quantity = order.quantity;
                    trade2.executionPrice = order.price;
                    trade2.originalOrderId = orders[0].orderNumber;
                    trade2.oppositeOrderId = order.orderNumber;
                    trade2.executionTime = DateTime.Now;
                    trade2.feeAmount = order.price * Convert.ToDecimal(order.quantity) * Convert.ToDecimal(.001);
                    Console.WriteLine("Trade Create: {0}", trade2.ToString());

                    // Throw away new order since it is fully matched
                    // Delete existing order since it is fully matched
                    orders.RemoveAt(0);
                }
                else if (order.quantity < (orders[0].quantity - orders[0].filledQuantity))
                {
                    Console.WriteLine("New Order is FULLY MATCHED");
                    orders[0].filledQuantity += order.quantity;
                    order.filledQuantity = order.quantity;
                    // Create trade
                    // Throw away new order since it is fully matched
                }
                else
                {
                    Console.WriteLine("Existing Order is FULLY MATCHED");
                    order.filledQuantity += orders[0].quantity - orders[0].filledQuantity;
                    orders[0].filledQuantity = orders[0].quantity;
                    // Create trade
                    // Add new order to queue since it is only partially matched
                    // Delete existing order since it is fully matched
                }
            }
        }
    }
}
