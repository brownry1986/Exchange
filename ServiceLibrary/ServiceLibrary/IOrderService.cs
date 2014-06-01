using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibrary;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        Order SubmitOrder(Order order);

        [OperationContract]
        List<Order> GetOrders(Int64 productId, Int64 traderId);

        [OperationContract]
        List<Trade> GetTrades(Int64 productId, Int64 traderId);

        [OperationContract]
        BidAsk GetBidAsk(Int64 productId);
    }

}
