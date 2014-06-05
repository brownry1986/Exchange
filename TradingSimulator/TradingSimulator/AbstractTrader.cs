using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using ClassLibrary;

namespace TradingSimulator
{
    public abstract class AbstractTrader : ITrader
    {
        abstract public void GeneratorOrders();

        protected void SubmitOrder(BuySell buySell, decimal price, long quantity)
        {
            Order order = new Order();
            order.buySell = buySell;
            order.orderType = OrderType.Limit;
            order.productId = 0;
            order.traderId = 0;
            order.quantity = quantity;
            order.price = price;

            Message message = new Message(MessageType.SubmitOrder, order);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
        }

        public double SimulateAsset(double so, double mu, double sigma, double tau, double delta)
        {
            double s = so;
            double nsteps = tau;
            for (int i = 0; i < (int)nsteps; i++)  //we could loop inside here for the price, I did it outside, but could easily remove
            {
                double r = Rand.Gauss(0.0, 1.0); //generate a gaussian random number mean 0 std. dev 1.0
                s = s * (1.0 + mu * delta + sigma * r * Math.Sqrt(delta)); //notice we are adjusting annual mu and sigma for delta (i.e. time)
            }
            return s;
        }

        public decimal SimulatePrice(double mu, double sigma)
        {
            return Convert.ToDecimal(Math.Round(Rand.Gauss(mu, sigma), 1));
        }

        public Int64 SimulateQuantity(double mu, double sigma)
        {
            return Convert.ToInt64(Math.Round(Rand.Gauss(mu, sigma)));
        }

        public BidAsk GetBidAsk()
        {
            Message message = new Message(MessageType.RetrieveBidAsk, (Int64)0);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            BidAsk bidAsk = (BidAsk)response.payload;
            Console.WriteLine("Bid/Ask : {0} / {1}", bidAsk.bidPrice, bidAsk.askPrice);
            return bidAsk;
        }

        public List<Trade> GetTrades(int lastTradeId)
        {
            Message message = new Message(MessageType.AdminRetrieveTrades, new Tuple<Int64, Int64>(0, lastTradeId));
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            return (List<Trade>)response.payload;
        }
    }
}
