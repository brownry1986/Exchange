using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Net.Sockets;
using ClassLibrary;

namespace ServiceLibrary
{

    public class AdminService : IAdminService
    {
        /*
         * Medthod to retreieve all orders for the selected product
         * 
         * Implemented by Ryan Brown
         */
        public List<Order> GetOrders(Int64 productId)
        {
            Message message = new Message(MessageType.AdminRetrieveOrders, productId);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            Console.WriteLine("Received Response - Message Type: {0}", response.messageType);
            Console.WriteLine("Received Response - Order: {0}", (List<Order>)response.payload);
            List<Order> orders = (List<Order>)response.payload;
            foreach (Order order in orders)
            {
                System.Console.WriteLine("Order Retrieved: {0}", order.ToString());
            }
            return orders;
        }

        /*
         * Medthod to retreieve all matched trades for the selected product with a trade id greater than the specified trade id
         * 
         * Implemented by Ryan Brown
         */
        public List<Trade> GetTrades(Int64 productId, Int64 tradeId)
        {
            Message message = new Message(MessageType.AdminRetrieveTrades, new Tuple<Int64, Int64>(productId, tradeId));
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            Console.WriteLine("Received Response - Message Type: {0}", response.messageType);
            Console.WriteLine("Received Response - Order: {0}", (List<Trade>)response.payload);
            List<Trade> trades = (List<Trade>)response.payload;
            foreach (Trade trade in trades)
            {
                System.Console.WriteLine("Trade Retrieved: {0}", trade.ToString());
            }
            return trades;
        }

        /*
         * Medthod to switch the trading mode and return the new mode
         * 
         * Implemented by Ryan Brown
         */
        public TradingMode SwitchTradingMode()
        {
            Message message = new Message(MessageType.AdminSwitchTradingMode, 0);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            Console.WriteLine("Received Response - Message Type: {0}", response.messageType);
            TradingMode tradingMode = (TradingMode)response.payload;
            Console.WriteLine("Received Response - Trading Mode: {0}", tradingMode);
            return tradingMode;
        }
    }
}
