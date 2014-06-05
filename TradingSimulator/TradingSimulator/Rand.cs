using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingSimulator
{
    static class Rand
    {
        private static Random random = new Random();

        public static double Gauss(double mu, double sigma)
        {
            double v1;
            double v2;
            double r;

            while (true)
            {
                v1 = random.NextDouble() * 2.0 - 1.0;
                v2 = random.NextDouble() * 2.0 - 1.0;
                r = (v1 * v1) + (v2 * v2);
                if (r < 1)
                    break;
            }
            return mu + sigma * Math.Sqrt(-2.0 * Math.Log(r) / r) * v1;
        }
    }
}
