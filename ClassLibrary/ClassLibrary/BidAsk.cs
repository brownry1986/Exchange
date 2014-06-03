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
    public class BidAsk
    {
        public BidAsk(decimal bidPrice, decimal askPrice)
        {
            this.bidPrice = bidPrice;
            this.askPrice = askPrice;
        }

        [DataMember]
        public virtual decimal bidPrice { get; set; }

        [DataMember]
        public virtual decimal askPrice { get; set; }

        public String getBidPriceValue()
        {
            return bidPrice == 0 ? "N/A" : Convert.ToString(bidPrice);
        }

        public String getAskPriceValue()
        {
            return askPrice == decimal.MaxValue ? "N/A" : Convert.ToString(askPrice);
        }
    }
}
