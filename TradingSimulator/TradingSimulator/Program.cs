using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace TradingSimulator
{
    /*
     * Startup class for trading simulator allows the user to choose the desired trading strategy
     * 
     * Implemented by Ryan Brown
     */
    public class Simulator
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Choose trader simluation:");
            Console.WriteLine("1. Simple Distributed");
            Console.WriteLine("2. Random Walk");
            Console.WriteLine("3. Hisorical");
            Console.WriteLine("4. Bid/Ask");
            Int64 strategy = Convert.ToInt64(Console.ReadLine());

            GetTradingStrategy(strategy).GeneratorOrders();
        }

        private static ITrader GetTradingStrategy(Int64 strategy)
        {
            switch (strategy)
            {
                case 1:
                    return new SimpleDistributedTrader();
                case 2:
                    return new RandomWalkTrader();
                case 3:
                    return new HistoricalTrader();
                case 4:
                    return new BidAskTrader();
                default:
                    return new SimpleDistributedTrader();
            }
        }
    }
}