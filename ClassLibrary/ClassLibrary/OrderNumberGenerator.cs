using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class OrderNumberGenerator
    {
        private static Int64 orderNumber = 0;

        public static Int64 getNext()
        {
            return orderNumber++;
        }
    }
}
