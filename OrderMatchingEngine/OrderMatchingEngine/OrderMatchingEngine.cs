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

namespace OrderMatchingEngine
{

    class OrderMatchingEngine
    {
        Dictionary<long, Account> accounts;

        static OrderBook orderBook;

        static void Main(string[] args)
        {
            if ( args.Length != 1 ) 
            {
                Console.WriteLine("Usasage: OrderMatching <product id>");
                return;
            }

            OrderMatchingEngine ome = new OrderMatchingEngine();
            ome.Initialize(Convert.ToInt64(args[0]));

        }

        protected void Initialize(Int64 productId)
        {
            orderBook = new OrderBook(productId);
            AsyncCallback callBack = new AsyncCallback(DoStuff);
            Messenger.Listen(callBack);
        }

        protected static Message ProcessMessage(Message message)
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

        protected static void DoStuff(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            ProcessMessageAsync caller = (ProcessMessageAsync)result.AsyncDelegate;
            Socket socket = caller.EndInvoke(result);

            Message message = Messenger.ReceiveMessage(socket);
            Console.WriteLine("In Callback - Message Type: {0}", message.messageType);
            Message response = ProcessMessage(message);
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
