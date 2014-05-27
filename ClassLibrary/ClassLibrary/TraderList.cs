using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class TraderList
    {

        public static List<Trader> traders = new List<Trader>();

        static TraderList()
        {
            traders.Add(new Trader(-1, ""));
            traders.Add(new Trader(0, "Max Gillman"));
            traders.Add(new Trader(1, "Chris Freeman"));
            traders.Add(new Trader(2, "Byron Housten"));
            traders.Add(new Trader(3, "Michael Liu"));
            traders.Add(new Trader(4, "Ryan Brown"));
        }
    }

}
