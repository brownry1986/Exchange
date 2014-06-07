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
            if (args.Length == 1)
            {
                GetTradingStrategy(args[0]).GeneratorOrders();
            }
            else
            {
                GetTradingStrategy("SimpleDistributed").GeneratorOrders();
            }

        }

        private static ITrader GetTradingStrategy(String strategy)
        {
            switch (strategy)
            {
                case "SimpleDistributed":
                    return new SimpleDistributedTrader();
                case "RandomWalk":
                    return new RandomWalkTrader();
                default:
                    return new SimpleDistributedTrader();
            }
        }
    }
}