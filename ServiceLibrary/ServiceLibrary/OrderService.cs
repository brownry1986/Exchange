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

    public class OrderService : IOrderService
    {
        public Order SubmitOrder(Order order)
        {
            Message message = new Message(MessageType.SubmitOrder, order);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            Console.WriteLine("Received Response - Message Type: {0}", response.messageType);
            Console.WriteLine("Received Response - Order: {0}", (Order)response.payload);
            System.Console.WriteLine("Order Submitted: {0}", order.ToString());
            return (Order)response.payload;
        }

        public List<Order> GetOrders(Int64 productId, Int64 traderId)
        {
            Message message = new Message(MessageType.RetrieveOrders, new Tuple<Int64, Int64>(productId, traderId));
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

        public List<Trade> GetTrades(Int64 productId, Int64 traderId)
        {
            Message message = new Message(MessageType.RetrieveTrades, new Tuple<Int64, Int64>(productId, traderId));
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

        public BidAsk GetBidAsk(Int64 productId)
        {
            Message message = new Message(MessageType.RetrieveBidAsk, productId);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            Console.WriteLine("Received Response - Message Type: {0}", response.messageType);
            BidAsk bidAsk = (BidAsk)response.payload;
            Console.WriteLine("Received Response - Bid/Ask: {0}/{1}", bidAsk.bidPrice, bidAsk.askPrice);
            return bidAsk;
        }
    }
}
