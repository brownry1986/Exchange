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

        //static OrderBook orderBook;

        static Dictionary<Int64, OrderBook> orderBooks = new Dictionary<Int64,OrderBook>();

        static Dictionary<Tuple<Int64, Int64>, List<Trade>> trades = new Dictionary<Tuple<Int64, Int64>, List<Trade>>();

        static List<BlockingCollection<Order>> orderQueues = new List<BlockingCollection<Order>>();

        static BlockingCollection<Trade> tradeQueue = new BlockingCollection<Trade>();

        static void Main(string[] args)
        {
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
                Matcher matcher = new Matcher(orderQueue, tradeQueue, orderBook);
                Thread matcherThread = new Thread(matcher.Match);
                matcherThread.Start();
            }

            TradeLoader tradeLoad = new TradeLoader();
            Thread tradeLoadThread = new Thread(tradeLoad.Start);
            tradeLoadThread.Start();

            OrderMatchingEngine ome = new OrderMatchingEngine();
            ome.Start();
        }

        public class TradeLoader
        {
            public void Start()
            {
                while(true)
                {
                    Trade trade = tradeQueue.Take();
                    List<Trade> tradeList;
                    if (trades.TryGetValue(new Tuple<Int64, Int64>(trade.traderId, trade.productId), out tradeList))
                    {
                        tradeList.Add(trade);
                        Console.WriteLine("Number of Trades: {0}", tradeList.Count);
                    }
                    else
                    {
                        tradeList = new List<Trade>();
                        tradeList.Add(trade);
                        trades.Add(new Tuple<Int64, Int64>(trade.traderId, trade.productId), tradeList);
                        Console.WriteLine("Number of Trades: {0}", tradeList.Count);
                    }
                }
            }
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
                case MessageType.RetrieveTrades:
                    return new RetrieveTradesAction().Execute(message);
                case MessageType.RetrieveBidAsk:
                    return new RetrieveBidAskAction().Execute(message);
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
                OrderBook orderBook;
                if (orderBooks.TryGetValue(order.productId, out orderBook))
                {
                    orderBook.addOrder(order);
                    BlockingCollection<Order> queue = orderQueues[Convert.ToInt32(order.productId)];
                    queue.Add(order);

                    Console.WriteLine("===================================");
                    Console.WriteLine("Bid / Ask = {0} / {1}", orderBook.getBidPrice(), orderBook.getAskPrice());

                    return new Message(MessageType.Success, order);
                }

                return new Message(MessageType.Failure, order);
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
                    List<Order> orders = orderBook.getOrders(tuple.Item2);
                    foreach (Order order in orders)
                    {
                        Console.WriteLine("Retrieved Order: {0}", order);
                    }
                    return new Message(MessageType.Success, orders);
                }
                return new Message(MessageType.Failure, message.payload);
            }

        }

        protected class RetrieveTradesAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Retreive Trades Action: {0}", (Tuple<Int64, Int64>)message.payload);
                List<Trade> retrievedTrades;
                if (trades.TryGetValue((Tuple<Int64, Int64>)message.payload, out retrievedTrades))
                {
                    foreach (Trade trade in retrievedTrades)
                    {
                        Console.WriteLine("Retrieved Trade: {0}", trade);
                    }
                    return new Message(MessageType.Success, retrievedTrades);
                }

                return new Message(MessageType.Success, new List<Trade>());
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
                    Console.WriteLine("===================================");
                    Console.WriteLine("Bid / Ask = {0} / {1}", orderBook.getBidPrice(), orderBook.getAskPrice());

                    return new Message(MessageType.Success, new Tuple<String, String>(orderBook.getBidPrice(), orderBook.getAskPrice()));
                }

                return new Message(MessageType.Failure, productId);
            }

        }

        protected class CancelOrderAction : IAction
        {
            public Message Execute(Message message)
            {
                Console.WriteLine("Cancel Order Action: {0}", (Tuple<Int64, Int64>)message.payload);
                Tuple<Int64, Int64> tuple = (Tuple<Int64, Int64>)message.payload;
                OrderBook orderBook;
                if (orderBooks.TryGetValue(tuple.Item1, out orderBook))
                {
                    if (orderBook.cancelOrder(tuple.Item2))
                    {
                        return new Message(MessageType.Success, message.payload);
                    }
                }
                return new Message(MessageType.Failure, message.payload);
            }

        }
    }

}
