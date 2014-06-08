using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingSimulator
{
    /*
     * Interface to define the contract for each trading strategy
     * 
     * Implemented by Ryan Brown
     */
    interface ITrader
    {
        void GeneratorOrders();
    }
}
