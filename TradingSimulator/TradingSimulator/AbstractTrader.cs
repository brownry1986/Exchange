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
    /*
     * Abstract class to implement methods used for different types of trading strategies
     * 
     * Implemented by Ryan Brown
     */
    public abstract class AbstractTrader : ITrader
    {
        abstract public void GeneratorOrders();

        /*
         * Method to create and submit an order given the price and quantity
         * 
         * Implemented by Ryan Brown and Max Gillman
         */
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

        /*
         * Method to simulate a random walk for a given product
         * 
         * Implemented by Max Gillman
         */
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

        /*
         * Method to generate and round a random price
         * 
         * Implemented by Max Gillman
         */
        public decimal SimulatePrice(double mu, double sigma)
        {
            return Convert.ToDecimal(Math.Round(Rand.Gauss(mu, sigma), 1));
        }

        /*
         * Method to generate and round a random quantity
         * 
         * Implemented by Max Gillman
         */
        public Int64 SimulateQuantity(double mu, double sigma)
        {
            return Convert.ToInt64(Math.Round(Rand.Gauss(mu, sigma)));
        }

        /*
         * Method to retrieve the bid/ask price
         * 
         * Implemented by Ryan Brown
         */
        public BidAsk GetBidAsk()
        {
            Message message = new Message(MessageType.RetrieveBidAsk, (Int64)0);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            BidAsk bidAsk = (BidAsk)response.payload;
            Console.WriteLine("Bid/Ask : {0} / {1}", bidAsk.bidPrice, bidAsk.askPrice);
            return bidAsk;
        }

        /*
         * Method to retrieve the given number of historical trades
         * 
         * Implemented by Ryan Brown
         */
        public List<Trade> GetTrades(int numberOfTrades)
        {
            Message message = new Message(MessageType.AdminRetrieveHistoricalTrades, new Tuple<Int64, Int64>(0, numberOfTrades));
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            return (List<Trade>)response.payload;
        }

        /*
         * Method to calculate the historical mean price given a list of trades
         * 
         * Implemented by Ryan Brown
         */
        protected double CalculateHistoricalMean(List<Trade> trades)
        {
            double totalAmount = 0;
            int totalQuantity = 0;

            foreach (Trade trade in trades)
            {
                totalAmount += Convert.ToDouble(trade.executionPrice) * trade.quantity;
                totalQuantity += (int)trade.quantity;
            }

            return totalAmount / totalQuantity;
        }

        /*
         * Method to calculate the historical variance in price given a list of trades
         * 
         * Implemented by Ryan Brown
         */
        protected double CalculateHistoricalVariance(List<Trade> trades)
        {
            double sum = 0;
            double sumSquare = 0;
            int count = 0;

            foreach (Trade trade in trades)
            {
                count++;
                sum += Convert.ToDouble(trade.executionPrice);
                sumSquare += Math.Pow(Convert.ToDouble(trade.executionPrice), 2);
            }
            return (sumSquare - (Math.Pow(sum, 2)) / count) / (count - 1);
        }
    }
}
