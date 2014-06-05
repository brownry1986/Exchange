using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace TradingSimulator
{
    public class Simulator
    {
        static void Main(String[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments");
                return;
            }

            GetTradingStrategy(args[0]).GeneratorOrders();
        }

        private static ITrader GetTradingStrategy(String strategy)
        {
            switch (strategy)
            {
                case "SimpleDistributed":
                    return new SimpleDistributedTrader();
                default :
                    return new SimpleDistributedTrader();
            }
        }
    }
}