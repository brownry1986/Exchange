using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Flags]
    public enum MessageType
    {
        Awknowledge = 0x00,
        SubmitOrder = 0x01,
        CancelOrder = 0x02,
        RetrieveOrders = 0x03,
        Success = 0x04,
        Failure = 0x05
    }
}
