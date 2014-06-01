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
        public BidAsk(String bidPrice, String askPrice)
        {
            this.bidPrice = bidPrice;
            this.askPrice = askPrice;
        }

        [DataMember]
        public virtual String bidPrice { get; set; }

        [DataMember]
        public virtual String askPrice { get; set; }
    }
}
