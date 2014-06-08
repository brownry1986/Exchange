using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    /*
     * Domain object for holding order information
     * 
     * Implemented by Ryan Brown
     */
    [Serializable]
    [DataContract]
    public class Order
    {
        [DataMember]
        public virtual Int64 orderNumber { get; set; }

        [DataMember]
        public virtual OrderType orderType { get; set; }

        [DataMember]
        public virtual BuySell buySell { get; set; }

        [DataMember]
        public virtual Int64 productId { get; set; }

        [DataMember]
        public virtual Int64 quantity { get; set; }

        [DataMember]
        public virtual Int64 filledQuantity { get; set; }

        [DataMember]
        public virtual Int64 unfilledQuantity { get { return quantity - filledQuantity; } set { } }

        [DataMember]
        public virtual decimal price { get; set; }

        [DataMember]
        public virtual DateTime submitTime { get; set; }

        [DataMember]
        public virtual Int64 traderId { get; set; }

        [DataMember]
        public virtual Boolean cancelled { get; set; }

        [DataMember]
        public virtual Boolean matched { get; set; }

        public String ToString()
        {
            return "orderNumber = " + orderNumber
                + "; orderType = " + orderType.ToString()
                + "; buySell = " + buySell.ToString()
                + "; product = " + productId
                + "; quantity = " + quantity
                + "; filledQuantity = " + filledQuantity
                + "; price = " + price.ToString()
                + "; cancelled = " + cancelled
                + "; matched = " + matched;
        }
    }
}
