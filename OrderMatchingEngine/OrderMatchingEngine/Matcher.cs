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

        Dictionary<decimal, List<Order>> buyQueue = new Dictionary<decimal, List<Order>>();

        Dictionary<decimal, List<Order>> sellQueue = new Dictionary<decimal, List<Order>>();

        public Matcher(BlockingCollection<Order> orderQueue)
        {
            this.orderQueue = orderQueue;
        }

        public void Match()
        {
            while (true)
            {
                Order order = orderQueue.Take();
                Console.WriteLine("Matcher got order: {0}", order.ToString());
                decimal price = order.price;
                if (order.buySell == BuySell.Buy)
                {
                    if (sellQueue.Keys.Count > 0 && price > sellQueue.Keys.Min())
                    {
                        Console.WriteLine("MATCH");
                        continue;
                    }
                    else
                    {
                        List<Order> openBuyOrders;
                        if (buyQueue.TryGetValue(price, out openBuyOrders))
                        {
                            openBuyOrders.Add(order);
                        }
                        else
                        {
                            openBuyOrders = new List<Order>();
                            openBuyOrders.Add(order);
                            buyQueue.Add(price, openBuyOrders);
                        }

                    }
                }
                else
                {
                    if (buyQueue.Keys.Count > 0 && price < buyQueue.Keys.Max())
                    {
                        Console.WriteLine("MATCH");
                        continue;
                    }
                    else
                    {
                        List<Order> openSellOrders = new List<Order>();
                        if (sellQueue.TryGetValue(price, out openSellOrders))
                        {
                            openSellOrders.Add(order);
                        }
                        else
                        {
                            openSellOrders = new List<Order>();
                            openSellOrders.Add(order);
                            sellQueue.Add(price, openSellOrders);
                        }
                    }
                }
                Console.WriteLine("NO MATCH");
            }
        }
    }
}
