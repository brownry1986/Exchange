﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;

namespace TradingSimulator
{
    class RandomWalkTrader : AbstractTrader
    {
        double startPrice;
        double variance;
        double distribution;
        Int64 numOrders;

        public RandomWalkTrader()
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
                nextPrice = SimulateAsset(nextPrice, variance, .2, 1, 1.0 / 252.0);
                Console.WriteLine("NextPrice = {0}", nextPrice);

                // Create new buy order
                nextPrice = Convert.ToDouble(SimulatePrice(nextPrice * (1 - distribution), variance));
                SubmitOrder(BuySell.Buy, Convert.ToDecimal(nextPrice), SimulateQuantity(200, 10));
                Console.WriteLine("Price: {0}; Variance: {1}", nextPrice, variance);

                // Create new sell order
                nextPrice = Convert.ToDouble(SimulatePrice(nextPrice * (1 + distribution), variance));
                SubmitOrder(BuySell.Sell, Convert.ToDecimal(nextPrice), SimulateQuantity(200, 10));

                Console.WriteLine("Price: {0}; Variance: {1}", nextPrice, variance);
                Thread.Sleep(1000);
            }
        }

    }
}
