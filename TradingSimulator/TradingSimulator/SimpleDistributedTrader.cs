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
    public class SimpleDistributedTrader : AbstractTrader
    {
        double startPrice;
        double variance;
        double distribution;
        Int64 numOrders;

        public SimpleDistributedTrader()
        {
            Console.Write("Enter start price: ");
            this.startPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter variance: ");
            this.variance = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter distribution: ");
            this.distribution = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter number of orders: ");
            this.numOrders = Convert.ToInt64(Console.ReadLine());
        }

        public override void GeneratorOrders()
        {
            double nextPrice = startPrice;
            //int lastTradeId = 0;
            for (int i = 0; i < numOrders; i++)
            {
                //nextPrice = SimulateAsset(nextPrice, variance, .2, 1, 1.0 / 252.0);
                Console.WriteLine("NextPrice = {0}", nextPrice);

                // Create new buy order
                SubmitOrder(BuySell.Buy, SimulatePrice(nextPrice * (1 - distribution), variance), SimulateQuantity(200, 10));

                // Create new sell order
                SubmitOrder(BuySell.Buy, SimulatePrice(nextPrice * (1 + distribution), variance), SimulateQuantity(200, 10));

                /*
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

                    nextPrice = totalAmount / totalQuantity;
                }

                BidAsk bidAsk = GetBidAsk();
                variance = Convert.ToDouble(bidAsk.askPrice - bidAsk.bidPrice) / 2;
                */
                Console.WriteLine("Mean: {0}; Variance: {1}", nextPrice, variance);
                Thread.Sleep(1000);
            }
        }
    }
}
