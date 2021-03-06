﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace AdminClient
{
    /*
     * Admin Form generates the UI for the administration client
     * 
     * Implemented by Ryan Brown
     */
    public partial class AdminForm : Form
    {
        protected static Boolean active = true;

        protected static long time = 0;

        protected static decimal previousPrice = 0;

        protected static int lastTradeId = 0;

        /*
         * Initial form object and kick off separate thread for refreshing the data in the form
         * 
         * Implemented by Ryan Brown
         */
        public AdminForm()
        {
            InitializeComponent();

            TradingMode tradingMode = TradingMode.Passive;
            this.tradingModeBox.Text = TradingModeText(tradingMode);

            Refresher refresher = new Refresher(this);
            Thread refresherThread = new Thread(refresher.Start);
            refresherThread.Start();
        }

        /*
         * Translate trading mode enumeration into text to displayin the UI
         * 
         * Implemented by Ryan Brown
         */
        private String TradingModeText(TradingMode tradingMode)
        {
            switch (tradingMode)
            {
                case TradingMode.Active :
                    return "Active";
                case TradingMode.Passive :
                    return "Passive";
                default :
                    return "Startup";
            }
        }

        /*
         * Upon clicking the Switch Trading Mode button, send command to the Matching Engine through the Admin Service to switch the trading mode
         * 
         * Implemented by Ryan Brown
         */
        private void tradingModeButton_Click(object sender, EventArgs e)
        {
            ServiceLibrary.IAdminService adminService = new ServiceLibrary.AdminService();
            TradingMode tradingMode = adminService.SwitchTradingMode();
            this.tradingModeBox.Text = TradingModeText(tradingMode);
        }

        /*
         * Upon closing the form, set the active flag to false so that other threads know to stop running
         * 
         * Implemented by Ryan Brown
         */
        private void form_Close(object sender, EventArgs e)
        {
            AdminForm.active = false;
        }

        /*
         * Refresh data displayed in the UI by retrieving data from the Matching Engine
         * 
         * Implemented by Ryan Brown
         */
        private void RefreshCharts()
        {
            Dictionary<decimal, long> buyPriceDepth = new Dictionary<decimal, long>();
            Dictionary<decimal, long> sellPriceDepth = new Dictionary<decimal, long>();

            ServiceLibrary.IAdminService adminService = new ServiceLibrary.AdminService();
            List<Order> orders = adminService.GetOrders(0);
            
            long buyOrders = 0;
            long buyQuantity = 0;
            long sellOrders = 0;
            long sellQuantity = 0;
            foreach (Order order in orders)
            {
                long quantity = order.unfilledQuantity;
                decimal price = order.price;

                if (quantity > 0)
                {
                    if (order.buySell == BuySell.Buy)
                    {
                        buyOrders++;
                        buyQuantity += quantity;

                        long depth;
                        if (buyPriceDepth.TryGetValue(price, out depth))
                        {
                            buyPriceDepth[price] = depth + quantity;
                        }
                        else
                        {
                            buyPriceDepth.Add(price, quantity);
                        }
                    }
                    else
                    {
                        sellOrders++;
                        sellQuantity += quantity;

                        long depth;
                        if (sellPriceDepth.TryGetValue(price, out depth))
                        {
                            sellPriceDepth[price] = depth + quantity;
                        }
                        else
                        {
                            sellPriceDepth.Add(price, quantity);
                        }
                    }
                }
            }

            this.buyCountBox.Text = Convert.ToString(buyOrders);
            this.buyQuantityBox.Text = Convert.ToString(buyQuantity);
            this.sellCountBox.Text = Convert.ToString(sellOrders);
            this.sellQuantityBox.Text = Convert.ToString(sellQuantity);

            System.Windows.Forms.DataVisualization.Charting.Series buySeries = chart1.Series[0];
            System.Windows.Forms.DataVisualization.Charting.Series sellSeries = chart1.Series[1];
            buySeries.Points.Clear();
            foreach (decimal price in buyPriceDepth.Keys)
            {
                Console.WriteLine("Adding point: {0} - {1}", price, buyPriceDepth[price]);
                buySeries.Points.AddXY(price, buyPriceDepth[price]);
            }

            sellSeries.Points.Clear();
            foreach (decimal price in sellPriceDepth.Keys)
            {
                Console.WriteLine("Adding point: {0} - {1}", price, sellPriceDepth[price]);
                sellSeries.Points.AddXY(price, sellPriceDepth[price]);
            }

            List<Trade> trades = adminService.GetTrades(0, lastTradeId);

            long tradeQuantity = 0;
            decimal totalPrice = 0;

            if (trades.Count > 0)
            {
                foreach (Trade trade in trades)
                {
                    totalPrice += trade.executionPrice * trade.quantity;
                    tradeQuantity += trade.quantity;
                }
                lastTradeId = (int)trades[trades.Count - 1].tradeId;
            }

            if (tradeQuantity > 0)
            {
                previousPrice = totalPrice / tradeQuantity;
            }

            if (previousPrice > 0)
            {
                System.Windows.Forms.DataVisualization.Charting.Series priceSeries = chart2.Series[0];
                priceSeries.Points.AddXY(time, previousPrice);

                System.Windows.Forms.DataVisualization.Charting.Series volumeSeries = chart3.Series[0];
                volumeSeries.Points.AddXY(time++, tradeQuantity / 2);
            }
        }

        /*
         * Class to run in a separate thread to periodically invoke the RefreshCharts method on the form
         * 
         * Implemented by Ryan Brown
         */
        protected class Refresher
        {
            AdminForm form;

            public Refresher(AdminForm form)
            {
                this.form = form;
            }

            /*
             * Upon starting the thread, sleep for 1 second then while the form is active continually refresh the charts every 5 seconds
             * 
             * Implemented by Ryan Brown
             */
            public void Start()
            {
                Thread.Sleep(1000);
                while (AdminForm.active)
                {
                    if (form != null)
                    {
                        form.Invoke(new MethodInvoker(() => Refresh()));
                    }
                    Thread.Sleep(5000);
                }
            }

            /*
             * Call the RefreshCharts method on the form object
             * 
             * Implemented by Ryan Brown
             */
            public void Refresh()
            {
                form.RefreshCharts();
            }
        }
    }
}
