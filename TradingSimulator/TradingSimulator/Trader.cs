using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Trader;
using ClassLibrary;

namespace Simulation
{
    class Trader
    {
        public double startprice;
        public double nextprice;
        public double risklevel;
        public double newsfreq;
        public int loops;

        private List<Order> buyOrders = new List<Order>();
        private List<Order> sellOrders = new List<Order>();

        private PriceSim walker;
        private Rand g;

        public Trader(double startprice, double risklevel, double newsfreq, int loops)
        {
            this.startprice = startprice;
            this.walker = new PriceSim();
            this.g = new Rand();
            this.nextprice = walker.SimulateAsset(startprice, .02, .2, 1, 1.0 / 252.0, g);
            this.risklevel = risklevel;
            this.newsfreq = newsfreq;
            this.loops = loops;
        }

        public void OrderGenerator()
        {
            for (int i = 0; i < loops; i++)
            {
                // Create new buy order
                Order buyOrder = new Order();
                buyOrder.buySell = BuySell.Buy;
                buyOrder.productId = 1;
                buyOrder.traderId = 0;
                buyOrder.quantity = Convert.ToInt64(SimQtyLog(100, 10));
                buyOrder.price = Convert.ToDecimal(SimPriceLog(nextprice * .90, 10.0));
                buyOrders.Add(buyOrder);
                SubmitOrder(buyOrder);

                // Create new sell order
                Order sellOrder = new Order();
                sellOrder.buySell = BuySell.Sell;
                sellOrder.productId = 1;
                sellOrder.traderId = 1;
                sellOrder.quantity = Convert.ToInt64(SimQtyLog(100, 10));
                sellOrder.price = Convert.ToDecimal(SimPriceLog(nextprice * 1.10, 10.0));
                sellOrders.Add(sellOrder);
                SubmitOrder(sellOrder);
            }
        }

        public double SimPriceLog(double mu, double sigma)
        {
            return Math.Round(g.Gauss(mu, sigma),2);
        }

        public double SimQtyLog(double mu, double sigma)
        {
            return Math.Round(g.Gauss(mu, sigma));
        }

        public void PrintOrders(BuySell buySell)
        {
            foreach(Order order in (buySell == BuySell.Buy ? buyOrders : sellOrders))
            {
                Console.WriteLine("Order: {0}", order.ToString());
            }
        }

        public void SubmitOrder(Order order)
        {
            Message message = new Message(MessageType.SubmitOrder, order);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
        }

        public void RetreiveOrders(Int64 traderId)
        {
            Message message = new Message(MessageType.RetrieveOrders, traderId);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            foreach (Order order in (List<Order>)response.payload)
            {
                Console.WriteLine("Order: {0}", order.ToString());
            }
        }
    }
    class Simulated
    {
        static void Main()
        {
            Trader max = new Trader(100.0, 2.0, 50.0, 10);
            max.OrderGenerator();
            Console.WriteLine("These are the buy orders:");
            max.PrintOrders(BuySell.Buy);
            Console.WriteLine("These are the sell orders:");
            max.PrintOrders(BuySell.Sell);
            Console.WriteLine("These are the orders submitted by trader 0:");
            max.RetreiveOrders(0);
            Console.WriteLine("These are the orders submitted by trader 1:");
            max.RetreiveOrders(1);
            Console.Read();
        }
    }
}
