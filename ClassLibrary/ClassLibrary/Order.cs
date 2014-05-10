using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Order
    {
        public virtual Int64 orderNumber { get; set; }
        
        public virtual OrderType orderType { get; set; }
        
        public virtual BuySell buySell { get; set; }
        
        public virtual Int64 productId { get; set; }

        public virtual Int64 quantity { get; set; }
        
        public virtual decimal price { get; set; }
        
        public virtual DateTime submitTime { get; set; }

        public virtual Int64 traderId { get; set; }

        public virtual Boolean cancelled { get; set; }

        public virtual Boolean matched { get; set; }

        public String ToString()
        {
            return "orderNumber = " + orderNumber
                + "; orderType = " + orderType.ToString()
                + "; buySell = " + buySell.ToString()
                + "; product = " + productId
                + "; quantity = " + quantity
                + "; price = " + price.ToString()
                + "; cancelled = " + cancelled
                + "; matched = " + matched;
        }
    }
}
