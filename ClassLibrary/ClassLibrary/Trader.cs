using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
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
