using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     * Class to generate a unique trade number upon request
     * 
     * Implemented by Ryan Brown
     */
    public class TradeNumberGenerator
    {
        private static Int64 tradeNumber = 0;

        public static Int64 getNext()
        {
            return tradeNumber++;
        }
    }
}
