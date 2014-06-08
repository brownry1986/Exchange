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
     * Trader strategy to simulate a trader submitting orders with prices based a normal distribution
     * 
     * Implemented by Max Gillman
     */
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
            for (int i = 0; i < numOrders; i++)
            {
                Console.WriteLine("NextPrice = {0}", nextPrice);

                // Create new buy order
                SubmitOrder(BuySell.Buy, SimulatePrice(nextPrice * (1 - distribution), variance), SimulateQuantity(200, 10));

                // Create new sell order
                SubmitOrder(BuySell.Sell, SimulatePrice(nextPrice * (1 + distribution), variance), SimulateQuantity(200, 10));

                Console.WriteLine("Mean: {0}; Variance: {1}", nextPrice, variance);
                Thread.Sleep(1000);
            }
        }
    }
}
