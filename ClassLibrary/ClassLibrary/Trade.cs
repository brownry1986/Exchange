using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    [DataContract]
    public class Trade
    {
        [DataMember]
        public virtual Int64 tradeId { get; set; }

        [DataMember]
        public virtual Int64 traderId { get; set; }

        [DataMember]
        public virtual Int64 productId { get; set; }

        [DataMember]
        public virtual BuySell buySell { get; set; }

        [DataMember]
        public virtual Int64 quantity { get; set; }

        [DataMember]
        public virtual decimal executionPrice { get; set; }

        [DataMember]
        public virtual decimal submissionPrice { get; set; }

        [DataMember]
        public virtual DateTime executionTime { get; set; }

        [DataMember]
        public virtual Int64 originalOrderId { get; set; }

        [DataMember]
        public virtual Int64 oppositeOrderId { get; set; }

        [DataMember]
        public virtual decimal feeAmount { get; set; }

        public String ToString()
        {
            return "tradeId = " + tradeId
                + "; trader = " + traderId
                + "; product = " + productId
                + "; buySell = " + buySell.ToString()
                + "; quantity = " + quantity
                + "; price = " + executionPrice.ToString()
                + "; original order = " + originalOrderId
                + "; opposite order = " + oppositeOrderId
                + "; fees = " + feeAmount.ToString();
        }
    }
}
