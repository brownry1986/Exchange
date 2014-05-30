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
        List<Order> GetOrders(Int64 traderId, Int64 productId);

        [OperationContract]
        List<Trade> GetTrades(Int64 traderId, Int64 productId);

        [OperationContract]
        void CancelOrder(Int64 traderId, Int64 orderNumber);

        /*
        [OperationContract]
        decimal GetAskPrice();

        [OperationContract]
        decimal GetBidPrice();
        */
    }

}
