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

        static Dictionary<Int64, OrderBook> orderBooks = new Dictionary<Int64,OrderBook>();

        static Dictionary<Tuple<Int64, Int64>, List<Trade>> trades = new Dictionary<Tuple<Int64, Int64>, List<Trade>>();

        static List<BlockingCollection<Order>> orderQueues = new List<BlockingCollection<Order>>();

        static BlockingCollection<Trade> tradeQueue = new BlockingCollection<Trade>();

        Thread[] matcherThreads;

        Thread tradeLoadThread;

        Thread listenerThread;

        public static Boolean running = true;

        protected static void LoadAccountInformation()
        {
            // Load traders account information from the agent back into memory
        }

        public void Start()
        {
            LoadAccountInformation();

            matcherThreads = new Thread[ProductList.products.Count - 2];

            foreach (Product product in ProductList.products)
            {
                if (product.productId < 0)
                {
                    continue;
                }
                BlockingCollection<Order> orderQueue = new BlockingCollection<Order>();
                orderQueues.Add(orderQueue);
                OrderBook orderBook = new OrderBook(product.productId);
                orderBooks.Add(product.productId, orderBook);

                Matcher matcher = new Matcher(orderQueue, tradeQueue);
                Thread matcherThread = new Thread(matcher.Match);
                matcherThread.Start();
                matcherThreads[product.productId] = matcherThread;
            }

            TradeLoader tradeLoad = new TradeLoader();
            tradeLoadThread = new Thread(tradeLoad.Start);
            tradeLoadThread.Start();

            MessageListener listener = new MessageListener();
            listenerThread = new Thread(listener.Start);
            listenerThread.Start();
        }

        public class MessageListener
        {
            public void Start()
            {
                AsyncCallback callBack = new AsyncCallback(ProcessMessage);
                Messenger.Listen(callBack);
            }
        }

        public void Stop()
        {
            running = false;
            listenerThread.Interrupt();

            foreach (Thread matcherThread in matcherThreads)
            {
                matcherThread.Interrupt();
            }

            tradeLoadThread.Interrupt();
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
                case MessageType.RetrieveTrades:
                    return new RetrieveTradesAction().Execute(message);
                case MessageType.RetrieveBidAsk:
                    return new RetrieveBidAskAction().Execute(message);
                case MessageType.AdminRetrieveOrders:
                    return new AdminRetrieveOrdersAction().Execute(message);
                case MessageType.AdminRetrieveTrades:
                    return new AdminRetrieveTradesAction().Execute(message);
                case MessageType.AdminRetrieveHistoricalTrades:
                    return new AdminRetrieveHistoricalTradesAction().Execute(message);
            }

            return new Message(MessageType.Failure, 0);
        }

        protected static void ProcessMessage(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            ProcessMessageAsync caller = (ProcessMessageAsync)result.AsyncDelegate;
            Socket socket = caller.EndInvoke(result);

            Message message = Messenger.ReceiveMessage(socket);
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
                if (ValidateOrder(order))
                {
                    OrderBook orderBook;
                    if (orderBooks.TryGetValue(order.productId, out orderBook))
                    {
                        orderBook.AddOrder(order);
                        UpdateAccountInformation(order);
                        BlockingCollection<Order> queue = orderQueues[Convert.ToInt32(order.productId)];
                        queue.Add(order);

                        return new Message(MessageType.Success, order);
                    }
                }

                return new Message(MessageType.Failure, order);
            }

            protected Boolean ValidateOrder(Order order)
            {
                if (order.quantity <= 0)
                {
                    Console.WriteLine("Order rejected, quantity is less than or equal to zero");
                    return false;
                }

                if (order.orderType == OrderType.Limit && order.price <= 0)
                {
                    Console.WriteLine("Order rejected, price is less than or equal to zero");
                    return false;
                }

                OrderBook orderBook;
                if (orderBooks.TryGetValue(order.productId, out orderBook))
                {
                    BidAsk bidAsk = orderBook.GetBidAskPrice();
                    // If there is an existing ask price, a new order cannot have a price more than 10 times that
                    if (bidAsk.askPrice < decimal.MaxValue && order.price > bidAsk.askPrice * 10)
                    {
                        Console.WriteLine("Order rejected, price is more than 10 times the current Ask Price");
                        return false;
                    }
                }

                return ValidateOrderAgainstAccount(order);
            }

            protected Boolean ValidateOrderAgainstAccount(Order order)
            {
                // Validate the order against the trader's account information
                return true;
            }

            protected void UpdateAccountInformation(Order order)
            {
                // Update the trader's account information based on the submitted order
            }
        }

        protected class RetrieveOrdersAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Orders Action: {0}", (Tuple<Int64, Int64>)message.payload);
                OrderBook orderBook;
                Tuple<Int64, Int64> tuple = (Tuple<Int64, Int64>)message.payload;
                if (orderBooks.TryGetValue(tuple.Item1, out orderBook))
                {
                    return new Message(MessageType.Success, orderBook.GetActiveOrders(tuple.Item2));
                }
                return new Message(MessageType.Failure, message.payload);
            }

        }

        protected class RetrieveTradesAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Trades Action: {0}", (Tuple<Int64, Int64>)message.payload);
                OrderBook orderBook;
                Tuple<Int64, Int64> tuple = (Tuple<Int64, Int64>)message.payload;
                if (orderBooks.TryGetValue(tuple.Item1, out orderBook))
                {
                    return new Message(MessageType.Success, orderBook.GetTrades(tuple.Item2));
                }
                return new Message(MessageType.Failure, message.payload);
            }
        }

        protected class AdminRetrieveOrdersAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Admin Retreive Orders Action: {0}", (Int64)message.payload);
                OrderBook orderBook;
                if (orderBooks.TryGetValue((Int64)message.payload, out orderBook))
                {
                    List<Order> orders = orderBook.GetActiveOrders();
                    Console.WriteLine("Retrieved all orders and sending back: Count = {0}", orders.Count());
                    return new Message(MessageType.Success, orders);
                }
                return new Message(MessageType.Failure, message.payload);
            }

        }

        protected class AdminRetrieveTradesAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Trades Action: {0}", (Tuple<Int64, Int64>)message.payload);
                OrderBook orderBook;
                Tuple<Int64, Int64> tuple = (Tuple<Int64, Int64>)message.payload;
                if (orderBooks.TryGetValue(tuple.Item1, out orderBook))
                {
                    return new Message(MessageType.Success, orderBook.GetRecentTrades(tuple.Item2));
                }
                return new Message(MessageType.Failure, message.payload);
            }
        }

        protected class AdminRetrieveHistoricalTradesAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Trades Action: {0}", (Tuple<Int64, Int64>)message.payload);
                OrderBook orderBook;
                Tuple<Int64, Int64> tuple = (Tuple<Int64, Int64>)message.payload;
                if (orderBooks.TryGetValue(tuple.Item1, out orderBook))
                {
                    return new Message(MessageType.Success, orderBook.GetHistoricalTrades(tuple.Item2));
                }
                return new Message(MessageType.Failure, message.payload);
            }
        }

        protected class RetrieveBidAskAction : IAction
        {
            public Message Execute(Message message)
            {
                Int64 productId = (Int64)message.payload;
                Console.WriteLine("Retrieve Bid Ask Action: {0}", productId);
                OrderBook orderBook;
                if (orderBooks.TryGetValue(productId, out orderBook))
                {
                    return new Message(MessageType.Success, orderBook.GetBidAskPrice());
                }

                return new Message(MessageType.Failure, productId);
            }

        }

        public class TradeLoader
        {
            public void Start()
            {
                while (OrderMatchingEngine.running)
                {
                    try
                    {
                        Trade trade = tradeQueue.Take();
                        UpdateAccountInformation(trade);

                        OrderBook orderBook;
                        if (orderBooks.TryGetValue(trade.productId, out orderBook))
                        {
                            orderBook.AddTrade(trade);
                        }
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine("Thread interrupted, stopping");
                    }
                }
            }

            protected void UpdateAccountInformation(Trade trade)
            {
                // Update the trader's account information based on the executed trade
            }

        }
    }
}
