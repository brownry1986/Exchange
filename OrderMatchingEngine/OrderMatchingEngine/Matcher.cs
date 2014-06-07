﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Matcher
    {
        BlockingCollection<Order> orderQueue;

        BlockingCollection<Trade> tradeQueue;

        Dictionary<decimal, List<Order>> buyQueue;

        Dictionary<decimal, List<Order>> sellQueue;

        public Matcher(BlockingCollection<Order> orderQueue, BlockingCollection<Trade> tradeQueue)
        {
            this.orderQueue = orderQueue;
            this.tradeQueue = tradeQueue;

            buyQueue = new Dictionary<decimal, List<Order>>();
            sellQueue = new Dictionary<decimal, List<Order>>();
        }

        public void Match()
        {
            while (OrderMatchingEngine.running)
            {
                if (OrderMatchingEngine.tradingMode == TradingMode.Startup)
                {
                    // Implement startup procedure
                }
                else
                {
                    try
                    {
                        Order bid = orderQueue.Take();
                        Console.WriteLine("Matcher got order: {0}", bid.ToString());

                        decimal bidPrice = bid.buySell == BuySell.Buy ? bid.price : -bid.price;

                        if (OrderMatchingEngine.tradingMode == TradingMode.Active)
                        {
                            MatchOrder(bid, bidPrice);
                        }

                        // If there is unfilled quantity add the order to the order book unless it is a market order
                        if (bid.unfilledQuantity > 0 && bid.orderType != OrderType.Market)
                        {
                            Console.WriteLine("New Order is not FULLY MATCHED, add to dictionary");
                            AddOrder(bid, -bidPrice);
                        }
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine("Thread interrupted, stopping");
                    }
                }
            }
        }

        public void MatchOrder(Order bid, decimal bidPrice)
        {
            Dictionary<decimal, List<Order>> offerQueue = GetOfferQueue(bid.buySell);
            Int64 quantity = bid.quantity;

            List<decimal> keys = new List<decimal>(offerQueue.Keys);
            keys.Sort();
            keys.Reverse();
            Stack<decimal> offerPrices = new Stack<decimal>(keys);
            decimal bestPrice = offerPrices.Count > 0 ? offerPrices.Peek() : 0;
            Console.WriteLine("Attempt to Match: Bid Price = {0}, Bid Quantity = {1}, Best Offer Price = {2}", bidPrice, quantity, (offerPrices.Count > 0 ? offerPrices.Peek() : 0));

            while (offerPrices.Count > 0)
            {
                decimal offerPrice = offerPrices.Pop();

                Console.WriteLine("Bid Price = {0}, Best Offer Price = {1}", bidPrice, offerPrice);
                if (bid.orderType == OrderType.Limit && bidPrice < offerPrice)
                {
                    Console.WriteLine("Bid and Best Offer Prices do not overlap");
                    return;
                }

                List<Order> existingOffers = new List<Order>();
                if (offerQueue.TryGetValue(offerPrice, out existingOffers))
                {
                    List<Order> offers = new List<Order>(existingOffers);

                    foreach (Order offer in offers)
                    {
                        Int64 matchedQuantity = Math.Min(bid.unfilledQuantity, offer.unfilledQuantity);
                        bid.filledQuantity += matchedQuantity;
                        offer.filledQuantity += matchedQuantity;
                        DateTime executionTime = DateTime.Now;

                        decimal matchedPrice = offer.price;
                        tradeQueue.Add(CreateTrade(bid, matchedQuantity, matchedPrice, offer.orderNumber, executionTime));
                        tradeQueue.Add(CreateTrade(offer, matchedQuantity, matchedPrice, bid.orderNumber, executionTime));

                        if (offer.unfilledQuantity == 0)
                        {
                            Console.WriteLine("Existing Order is FULLY MATCHED, remove");
                            existingOffers.Remove(offer);
                            if (existingOffers.Count == 0)
                            {
                                Console.WriteLine("All offers at offer price {0} are FULLY MATCHED, remove");
                                offerQueue.Remove(offerPrice);
                            }
                        }

                        if (bid.unfilledQuantity == 0)
                        {
                            Console.WriteLine("New Order is FULLY MATCHED, stop");
                            return;
                        }
                    }
                }
            }
        }

        public void AddOrder(Order order, decimal price)
        {
            Dictionary<decimal, List<Order>> bidQueue = GetBidQueue(order.buySell);
            List<Order> openOrders;
            if (bidQueue.TryGetValue(price, out openOrders))
            {
                openOrders.Add(order);
            }
            else
            {
                openOrders = new List<Order>();
                openOrders.Add(order);
                bidQueue.Add(price, openOrders);
            }
        }

        public Trade CreateTrade(Order order, Int64 matchedQuantity, decimal matchedPrice, Int64 oppositeOrderId, DateTime executionTime)
        {
            Trade trade = new Trade();
            trade.tradeId = TradeNumberGenerator.getNext();
            trade.traderId = order.traderId;
            trade.productId = order.productId;
            trade.buySell = order.buySell;
            trade.quantity = matchedQuantity;
            trade.executionPrice = matchedPrice;
            trade.submissionPrice = order.price;
            trade.originalOrderId = order.orderNumber;
            trade.oppositeOrderId = oppositeOrderId;
            trade.executionTime = executionTime;
            trade.feeAmount = matchedPrice * Convert.ToDecimal(matchedQuantity) * Convert.ToDecimal(.001);
            Console.WriteLine("Trade Created: {0}", trade.ToString());
            return trade;
        }

        private Dictionary<decimal, List<Order>> GetBidQueue(BuySell buySell)
        {
            return buySell == BuySell.Buy ? buyQueue : sellQueue;
        }

        private Dictionary<decimal, List<Order>> GetOfferQueue(BuySell buySell)
        {
            return buySell == BuySell.Buy ? sellQueue : buyQueue;
        }
    }
}
