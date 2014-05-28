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

        public List<Order> GetOrders(Int64 traderId, Int64 productId)
        {
            Message message = new Message(MessageType.RetrieveOrders, new Tuple<Int64, Int64>(traderId, productId));
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

        public void CancelOrder(Int64 traderId, Int64 orderNumber)
        {
            Message message = new Message(MessageType.CancelOrder, orderNumber);
            Socket socket = Messenger.SendMessage(message);
            Message response = Messenger.ReceiveMessage(socket);
            Console.WriteLine("Received Response - Message Type: {0}", response.messageType);
            Console.WriteLine("Received Response - Order: {0}", (Int64)response.payload);
        }

        /*
        public decimal GetAskPrice()
        {
            return OrderBook.getAskPrice();
        }

        public decimal GetBidPrice()
        {
            return OrderBook.getBidPrice();
        }
        */
    }
}
