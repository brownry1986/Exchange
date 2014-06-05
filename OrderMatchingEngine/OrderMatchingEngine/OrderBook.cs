using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace OrderMatchingEngine
{
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

        public List<Order> GetActiveOrders(Int64 traderId)
        {
            List<Order> orders;
            if (ordersByTrader.TryGetValue(traderId, out orders))
            {
                List<Order> returnList = new List<Order>();
                foreach (Order order in orders)
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

        public BidAsk GetBidAskPrice()
        {
            decimal bestBid = 0;
            decimal bestAsk = decimal.MaxValue;

            foreach (Order order in allOrders)
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

        public List<Trade> GetTrades(Int64 traderId)
        {
            List<Trade> trades;
            if (tradesByTrader.TryGetValue(traderId, out trades))
            {
                return trades;
            }
            return new List<Trade>();
        }

        public List<Order> GetActiveOrders()
        {
            List<Order> activeOrders = new List<Order>();
            foreach (Order order in allOrders)
            {
                if (order.unfilledQuantity > 0)
                {
                    activeOrders.Add(order);
                }
            }
            return activeOrders;
        }

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
    }
}
