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
    public interface IAdminService
    {
        [OperationContract]
        List<Order> GetOrders(Int64 productId);

        [OperationContract]
        List<Trade> GetTrades(Int64 productId);
    }
}
