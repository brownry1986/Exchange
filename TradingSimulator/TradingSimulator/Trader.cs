using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            //this.nextprice = walker.SimulateAsset(startprice, .02, .2, 1, 1.0 / 252.0, g);
            this.risklevel = risklevel;
            this.newsfreq = newsfreq;
            this.loops = loops;
        }

        public void OrderGenerator(double startprice, double variance)
        {
            int lastTradeId = 0;
            for (int i = 0; i < loops; i++)
            {
                nextprice = walker.SimulateAsset(startprice, variance, .2, 1, 1.0 / 252.0, g);

                // Create new buy order
                Order buyOrder = new Order();
                buyOrder.buySell = BuySell.Buy;
                buyOrder.orderType = OrderType.Limit;
                buyOrder.productId = 0;
                buyOrder.traderId = 0;
                buyOrder.quantity = Convert.ToInt64(SimQtyLog(200, 10));
                buyOrder.price = Convert.ToDecimal(SimPriceLog(nextprice * .95, 5.0));
                buyOrders.Add(buyOrder);
                SubmitOrder(buyOrder);

                // Create new sell order
                Order sellOrder = new Order();
                sellOrder.buySell = BuySell.Sell;
                sellOrder.orderType = OrderType.Limit;
                sellOrder.productId = 0;
                sellOrder.traderId = 1;
                sellOrder.quantity = Convert.ToInt64(SimQtyLog(500, 10));
                sellOrder.price = Convert.ToDecimal(SimPriceLog(nextprice * 1.05, 5.0));
                sellOrders.Add(sellOrder);
                SubmitOrder(sellOrder);
                GetBidAsk();
                Thread.Sleep(1000);

                double totalAmount = 0;
                int totalQuantity = 0;
                List<Trade> trades = GetTrades(lastTradeId);
                if (trades.Count > 0)
                {
                    foreach (Trade trade in trades)
                    {
                        totalAmount += Convert.ToDouble(trade.executionPrice) * trade.quantity;
                        totalQuantity += (int)trade.quantity;
                    }
                    lastTradeId = (int)trades.Last().tradeId;

                    startprice = totalAmount / totalQuantity;
                }

                BidAsk bidAsk = GetBidAsk();
                double bidPrice = bidAsk.bidPrice.Equals("N/A") ? 0 : Convert.ToDouble(bidAsk.bidPrice);
                double askPrice = bidAsk.askPrice.Equals("N/A") ? 0 : Convert.ToDouble(bidAsk.askPrice);
                variance = (askPrice - bidPrice) / 2;

                Console.WriteLine("Mean: {0}; Variance: {1}", startprice, variance);
            }
        }

        public List<Trade> GetTrades(int lastTradeId)
        {
            Message message = new Message(MessageType.AdminRetrieveTrades, new Tuple<Int64, Int64>(0, lastTradeId));
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            return (List<Trade>)response.payload;
        }

        public double SimPriceLog(double mu, double sigma)
        {
            return Math.Round(g.Gauss(mu, sigma),1);
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

        public BidAsk GetBidAsk() 
        {
            Message message = new Message(MessageType.RetrieveBidAsk, (Int64)0);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            BidAsk bidAsk = (BidAsk)response.payload;
            Console.WriteLine("Bid/Ask : {0} / {1}", bidAsk.bidPrice, bidAsk.askPrice);
            decimal bidPrice = bidAsk.bidPrice.Equals("N/A") ? 0 : Convert.ToDecimal(bidAsk.bidPrice);
            decimal askPrice = bidAsk.askPrice.Equals("N/A") ? 0 : Convert.ToDecimal(bidAsk.askPrice);

            Console.WriteLine("Mean: {0}; Variance: {1}", (askPrice / 2 + bidPrice / 2), askPrice / 2 - bidPrice /2);
            return bidAsk;
        }

        public void RetreiveOrders(Int64 traderId)
        {
            Message message = new Message(MessageType.RetrieveOrders, new Tuple<Int64, Int64>(0, traderId));
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
            Trader max = new Trader(100.0, 2.0, 50.0, 1000);
            while (true)
            {
                max.OrderGenerator(100.0, 2.0);
            }
        }
    }
}
