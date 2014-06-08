using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /*
     * Domain object for trader order information
     * 
     * Implemented by Ryan Brown
     */
    public class Trader
    {
        public Trader(Int64 traderId, String name) 
        {
            this.traderId = traderId;
            this.name = name;
        }

        public Int64 traderId { get; set; }

        public String name { get; set; }

    }
}
