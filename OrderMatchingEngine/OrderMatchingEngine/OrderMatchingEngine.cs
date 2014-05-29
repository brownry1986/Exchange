using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ClassLibrary;
using System.Runtime.Remoting.Messaging;
using System.Collections.Concurrent;

namespace OrderMatchingEngine
{

    class OrderMatchingEngine
    {

        static OrderBook orderBook;

        static List<BlockingCollection<Order>> orderQueues = new List<BlockingCollection<Order>>();

        static BlockingCollection<Trade> tradeQueue = new BlockingCollection<Trade>();

        static void Main(string[] args)
        {
            foreach (Product product in ProductList.products) 
            {
                BlockingCollection<Order> queue = new BlockingCollection<Order>();
                orderQueues.Add(queue);
                Matcher matcher = new Matcher(queue, tradeQueue);
                Thread matcherThread = new Thread(matcher.Match);
                matcherThread.Start();
            }

            OrderMatchingEngine ome = new OrderMatchingEngine();
            orderBook = new OrderBook();
            ome.Start();
        }

        protected void Start()
        {
            AsyncCallback callBack = new AsyncCallback(ProcessMessage);
            Messenger.Listen(callBack);
        }

        protected static Message ProcessAction(Message message)
        {
            Message response = new Message(MessageType.Failure, 0);
            switch (message.messageType)
            {
                case MessageType.SubmitOrder:
                    return new SubmitOrderAction().Execute(message);
                case MessageType.RetrieveOrders:
                    return new RetrieveOrdersAction().Execute(message);
                case MessageType.CancelOrder:
                    return new CancelOrderAction().Execute(message);
            }

            return new Message(MessageType.Failure, 0);
        }

        protected static void ProcessMessage(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            ProcessMessageAsync caller = (ProcessMessageAsync)result.AsyncDelegate;
            Socket socket = caller.EndInvoke(result);

            Message message = Messenger.ReceiveMessage(socket);
            Console.WriteLine("In Callback - Message Type: {0}", message.messageType);
            Message response = ProcessAction(message);
            Messenger.SendMessage(socket, response);
            socket.Close();
        }

        protected class SubmitOrderAction : IAction
        {
            public Message Execute(Message message)
            {
                Order order = (Order)message.payload;
                Console.WriteLine("Submit Order Action: {0}", order);
                orderBook.addOrder(order);
                BlockingCollection<Order> queue = orderQueues[Convert.ToInt32(order.productId)];
                queue.Add(order);
                // Need to ensure that changes made to an order in the match engine are reflected in the order book
                return new Message(MessageType.Success, order);
            }

        }

        protected class RetrieveOrdersAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Orders Action: {0}", (Tuple<Int64, Int64>)message.payload);
                List<Order> orders = orderBook.getOrders((Tuple<Int64, Int64>)message.payload);
                foreach ( Order order in orders ) 
                {
                    Console.WriteLine("Retrieved Order: {0}", order);
                }
                return new Message(MessageType.Success, orderBook.getOrders((Tuple<Int64, Int64>)message.payload));
            }

        }

        protected class CancelOrderAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Cancel Order Action: {0}", message.payload);
                if (orderBook.cancelOrder((Int64)message.payload))
                {
                    return new Message(MessageType.Success, message.payload);
                }
                return new Message(MessageType.Failure, message.payload);
            }

        }
    }

}
