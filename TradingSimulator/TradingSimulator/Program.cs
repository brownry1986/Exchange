using System;
using System.Text;

namespace Trader
{
    class PriceSim
    {
        public double SimulateAsset(double so, double mu, double sigma, double tau, double delta, Rand g)
        {
            double s = so;
            double nsteps = tau;
            for (int i = 0; i < (int)nsteps; i++)  //we could loop inside here for the price, I did it outside, but could easily remove
            {
                double r = g.Gauss(0.0, 1.0); //generate a gaussian random number mean 0 std. dev 1.0
                s = s * (1.0 + mu * delta + sigma * r * Math.Sqrt(delta)); //notice we are adjusting annual mu and sigma for delta (i.e. time)
            }
            return s;
        }

    }

    class Rand : Random
    {
        private double v1;
        private double v2;
        private double r;

        public double Gauss(double mu, double sigma)
        {
            while (true)
            {
                v1 = NextDouble()*2.0-1.0;
                v2 = NextDouble()*2.0-1.0;
                r = (v1 * v1) + (v2 * v2);
                if (r<1)
                    break;
            }
            return mu + sigma * Math.Sqrt(-2.0 * Math.Log(r) / r) * v1;
        }


    }
    class Pricing
    {
        static void Testing1()
        {
            Rand gaussiannumber = new Rand();
            PriceSim testing = new PriceSim();
            double updatedprice = 100.0;  //Starting price

            for (int i = 0; i < 10; i++) //let the price walk for 10 days
            {
                updatedprice = testing.SimulateAsset(updatedprice, .10, .3, 1, 1.0/252.0, gaussiannumber);                
            }
            Console.WriteLine(updatedprice); //output price after ten days
        }
    }
}