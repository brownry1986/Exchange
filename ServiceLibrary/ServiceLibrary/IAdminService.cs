using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibrary;

namespace ServiceLibrary
{
    /*
     * Interface to define contract for Administration Service
     * 
     * Implemented by Ryan Brown
     */
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        List<Order> GetOrders(Int64 productId);

        [OperationContract]
        List<Trade> GetTrades(Int64 productId, Int64 tradeId);

        [OperationContract]
        TradingMode SwitchTradingMode();
    }
}
