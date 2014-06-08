using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace OrderMatchingLibrary
{
    /*
     * Order Book stores the order and trade information for a single product and provides accessor methods
     * 
     * Implemented by Ryan Brown
     */
    public class OrderBook
    {
        private Int64 productId;

        private List<Order> allOrders = new List<Order>();

        private Dictionary<Int64, List<Order>> ordersByTrader = new Dictionary<Int64, List<Order>>();

        private List<Trade> allTrades = new List<Trade>();

        private Dictionary<Int64, List<Trade>> tradesByTrader = new Dictionary<Int64, List<Trade>>();

        public OrderBook(Int64 productId)
        {
            this.productId = productId;
        }

        /*
         * Add a new order to the order book
         * 
         * Implemented by Ryan Brown
         */
        public void AddOrder(Order order)
        {
            order.orderNumber = OrderNumberGenerator.getNext();
            order.submitTime = DateTime.Now;

            allOrders.Add(order);

            List<Order> orders;
            if (ordersByTrader.TryGetValue(order.traderId, out orders))
            {
                orders.Add(order);
            }
            else
            {
                orders = new List<Order>();
                orders.Add(order);
                ordersByTrader.Add(order.traderId, orders);
            }
        }

        /*
         * Retrieve active orders from the order book for a specified trader
         * 
         * Implemented by Ryan Brown
         */
        public List<Order> GetActiveOrders(Int64 traderId)
        {
            List<Order> orders;
            if (ordersByTrader.TryGetValue(traderId, out orders))
            {
                List<Order> currentOrders = new List<Order>(orders);
                List<Order> returnList = new List<Order>();
                foreach (Order order in currentOrders)
                {
                    if (order.unfilledQuantity > 0)
                    {
                        returnList.Add(order);
                    }
                }
                return returnList;
            }
            return new List<Order>();
        }

        /*
         * Retrieve the current bid/ask price from the order book
         * 
         * Implemented by Ryan Brown
         */
        public BidAsk GetBidAskPrice()
        {
            decimal bestBid = 0;
            decimal bestAsk = decimal.MaxValue;

            List<Order> currentOrders = new List<Order>(allOrders);
            foreach (Order order in currentOrders)
            {
                if (order.unfilledQuantity > 0 && order.orderType == OrderType.Limit)
                {
                    if (order.buySell == BuySell.Buy && order.price > bestBid)
                    {
                        bestBid = order.price;
                    }

                    if (order.buySell == BuySell.Sell && order.price < bestAsk)
                    {
                        bestAsk = order.price;
                    }
                }
            }

            return new BidAsk(bestBid, bestAsk);
        }

        /*
         * Add a matched trade to the order book
         * 
         * Implemented by Ryan Brown
         */
        public void AddTrade(Trade trade)
        {
            allTrades.Add(trade);

            List<Trade> trades;
            if (tradesByTrader.TryGetValue(trade.traderId, out trades))
            {
                trades.Add(trade);
            }
            else
            {
                trades = new List<Trade>();
                trades.Add(trade);
                tradesByTrader.Add(trade.traderId, trades);
            }
        }

        /*
         * Retrieve matched trades from the order book for a specified trader
         * 
         * Implemented by Ryan Brown
         */
        public List<Trade> GetTrades(Int64 traderId)
        {
            List<Trade> trades;
            if (tradesByTrader.TryGetValue(traderId, out trades))
            {
                return new List<Trade>(trades);
            }
            return new List<Trade>();
        }

        /*
         * Retrieve all active orders from the order book
         * 
         * Implemented by Ryan Brown
         */
        public List<Order> GetActiveOrders()
        {
            List<Order> activeOrders = new List<Order>();
            List<Order> currentOrders = new List<Order>(allOrders);
            foreach (Order order in currentOrders)
            {
                if (order.unfilledQuantity > 0)
                {
                    activeOrders.Add(order);
                }
            }
            return activeOrders;
        }

        /*
         * Retrieve trades from the order book since the last trade id passed in
         * 
         * Implemented by Ryan Brown
         */
        public List<Trade> GetRecentTrades(Int64 lastTradeReturned)
        {
            Int64 startIndex = lastTradeReturned + 1;
            int endIndex = allTrades.Count - 1;

            lastTradeReturned = endIndex;

            if (startIndex <= endIndex)
            {
                return allTrades.GetRange((int)startIndex, endIndex - (int)startIndex);
            }
            return new List<Trade>();
        }

        /*
         * Retrieve the sepecified number of trades from the order book
         * 
         * Implemented by Ryan Brown
         */
        public List<Trade> GetHistoricalTrades(Int64 numberOfTrades)
        {
            int endIndex = allTrades.Count - 1;
            Int64 startIndex = Math.Max(0, endIndex - numberOfTrades);

            if (startIndex <= endIndex)
            {
                return allTrades.GetRange((int)startIndex, endIndex - (int)startIndex);
            }
            return new List<Trade>();
        }

        /*
         * Retrieve the depth of the order book
         * 
         * Implemented by Ryan Brown
         */
        public Int64 GetOrderDepth(BuySell buySell)
        {
            Int64 depth = 0;
            List<Order> currentOrders = new List<Order>(allOrders);
            foreach (Order order in currentOrders)
            {
                if (order.buySell == buySell)
                {
                    depth += order.unfilledQuantity;
                }
            }
            return depth;
        }
    }
}
