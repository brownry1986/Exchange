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

        static void Main(string[] args)
        {
            if ( args.Length != 1 ) 
            {
                Console.WriteLine("Usasage: OrderMatching <product id>");
                return;
            }

            List<Product> products= new List<Product>();
            products.Add(new Product(0, "Midwest Agricultural"));
            products.Add(new Product(1, "Midwest Industrial"));
            products.Add(new Product(2, "Midwest Technical"));
            products.Add(new Product(3, "Midwest Northeast Manufacturing"));
            products.Add(new Product(4, "California Agricultural"));
            products.Add(new Product(5, "California Technical"));

            //orderQueues = new List<Queue<Order>>();

            //MessageProcessor messageProcessor = new MessageProcessor(new ActionLibrary());
            //Thread messageThread = new Thread(messageProcessor.Process);
            //messageThread.Start();

            foreach(Product product in products) 
            {
                BlockingCollection<Order> queue = new BlockingCollection<Order>();
                orderQueues.Add(queue);
                Matcher matcher = new Matcher(queue);
                Thread matcherThread = new Thread(matcher.Match);
                matcherThread.Start();
            }
            //Queue<Order> orderQueue = new Queue<Order>();
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
                return new Message(MessageType.Success, order);
            }

        }

        protected class RetrieveOrdersAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Orders Action: {0}", (Int64)message.payload);
                return new Message(MessageType.Success, orderBook.getOrders((Int64)message.payload));
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
