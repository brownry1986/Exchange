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

namespace OrderMatchingLibrary
{
    public class Matcher
    {
        BlockingCollection<Order> orderQueue;

        BlockingCollection<Trade> tradeQueue;

        Dictionary<decimal, List<Order>> buyQueue;

        Dictionary<decimal, List<Order>> sellQueue;

        Boolean startupComplete;

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
                try
                {
                    if (OrderMatchingEngine.tradingMode == TradingMode.Startup)
                    {
                        if (startupComplete)
                        {
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            startupComplete = true;
                            StartupMode();
                        }
                    }
                    else
                    {
                        startupComplete = false;
                        MatchingMode();
                    }
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine("Thread interrupted, stopping");
                }
            }
        }

        private void StartupMode()
        {
            List<Trade> trades = StartupMatching();

            if (trades.Count > 0)
            {
                decimal matchedPrice = trades.Last().executionPrice;
                Console.WriteLine("In Startup, matched {0} trades, median price = {1}", trades.Count, matchedPrice);
                foreach (Trade trade in trades)
                {
                    trade.executionPrice = matchedPrice;
                    trade.feeAmount = matchedPrice * Convert.ToDecimal(trade.quantity) * Convert.ToDecimal(.001);
                    tradeQueue.Add(trade);
                }
            }
        }

        private void MatchingMode()
        {
            Order bid = orderQueue.Take();
            Console.WriteLine("Matcher got order: {0}", bid.ToString());

            if (OrderMatchingEngine.tradingMode == TradingMode.Active)
            {
                List<Trade> trades = MatchOrder(bid);
                foreach(Trade trade in trades)
                {
                    tradeQueue.Add(trade);
                }
            }

            // If there is unfilled quantity add the order to the order book unless it is a market order
            if (bid.unfilledQuantity > 0 && bid.orderType != OrderType.Market)
            {
                Console.WriteLine("New Order is not FULLY MATCHED, add to dictionary");
                AddOrder(bid);
            }
        }

        private List<Trade> StartupMatching()
        {
            List<decimal> keys = new List<decimal>(buyQueue.Keys);
            keys.Sort();
            keys.Reverse();
            List<Trade> allMatchedTrades = new List<Trade>();

            foreach (decimal key in keys)
            {
                List<Order> bids;
                if (buyQueue.TryGetValue(key, out bids))
                {
                    List<Order> matchingBids = new List<Order>(bids);

                    foreach (Order bid in matchingBids)
                    {
                        List<Trade> matchedTrades = MatchOrder(bid);
                        if (bid.unfilledQuantity == 0)
                        {
                            bids.Remove(bid);
                            if (bids.Count == 0)
                            {
                                buyQueue.Remove(key);
                            }
                        }

                        if (matchedTrades.Count == 0)
                        {
                            return allMatchedTrades;
                        }
                        allMatchedTrades.AddRange(matchedTrades);
                    }
                }
            }
            return allMatchedTrades;
        }

        private List<Trade> MatchOrder(Order bid)
        {
            Dictionary<decimal, List<Order>> offerQueue = GetOfferQueue(bid.buySell);
            Int64 quantity = bid.quantity;
            decimal bidPrice = bid.price;

            List<Trade> trades = new List<Trade>();
            Stack<decimal> offerPrices = GetOfferPrices(bid.buySell, offerQueue);

            while (offerPrices.Count > 0)
            {
                decimal offerPrice = offerPrices.Pop();

                Console.WriteLine("Bid Price = {0}, Best Offer Price = {1}", bidPrice, offerPrice);
                if (bid.orderType == OrderType.Limit)
                {
                    if (bid.buySell == BuySell.Buy && bidPrice < offerPrice)
                    {
                        Console.WriteLine("Bid and Best Offer Prices do not overlap");
                        return trades;
                    }

                    if (bid.buySell == BuySell.Sell && bidPrice > offerPrice)
                    {
                        Console.WriteLine("Bid and Best Offer Prices do not overlap");
                        return trades;
                    }
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
                        if (OrderMatchingEngine.tradingMode == TradingMode.Active || OrderMatchingEngine.tradingMode == TradingMode.Startup)
                        {
                            //tradeQueue.Add(CreateTrade(bid, matchedQuantity, matchedPrice, offer.orderNumber, executionTime));
                            //tradeQueue.Add(CreateTrade(offer, matchedQuantity, matchedPrice, bid.orderNumber, executionTime));
                            trades.Add(CreateTrade(bid, matchedQuantity, matchedPrice, offer.orderNumber, executionTime));
                            trades.Add(CreateTrade(offer, matchedQuantity, matchedPrice, bid.orderNumber, executionTime));
                        }

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
                            return trades;
                        }
                    }
                }
            }
            return trades;
        }

        public Stack<decimal> GetOfferPrices(BuySell bidBuySell, Dictionary<decimal, List<Order>> offerQueue)
        {
            List<decimal> keys = new List<decimal>(offerQueue.Keys);
            keys.Sort();
            if (bidBuySell == BuySell.Buy)
            {
                keys.Reverse();
            }

            return new Stack<decimal>(keys);
        }

        public void AddOrder(Order order)
        {
            Dictionary<decimal, List<Order>> bidQueue = GetBidQueue(order.buySell);
            List<Order> openOrders;
            if (bidQueue.TryGetValue(order.price, out openOrders))
            {
                openOrders.Add(order);
            }
            else
            {
                openOrders = new List<Order>();
                openOrders.Add(order);
                bidQueue.Add(order.price, openOrders);
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
