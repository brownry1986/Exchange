using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     * Class to generate a unique order number upon request
     * 
     * Implemented by Ryan Brown
     */
    public static class OrderNumberGenerator
    {
        private static Int64 orderNumber = 0;

        public static Int64 getNext()
        {
            return orderNumber++;
        }
    }
}
