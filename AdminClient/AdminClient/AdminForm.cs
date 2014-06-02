using System;
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
    public partial class AdminForm : Form
    {
        protected static Boolean active = true;

        protected static long time = 0;

        protected static decimal previousPrice = 0;

        public AdminForm()
        {
            InitializeComponent();
            Refresher refresher = new Refresher(this);
            Thread refresherThread = new Thread(refresher.Start);
            refresherThread.Start();
        }

        private void form_Close(object sender, EventArgs e)
        {
            AdminForm.active = false;
        }

        private void RefreshCharts()
        {
            Dictionary<decimal, long> buyPriceDepth = new Dictionary<decimal, long>();
            Dictionary<decimal, long> sellPriceDepth = new Dictionary<decimal, long>();

            ServiceLibrary.IAdminService adminService = new ServiceLibrary.AdminService();
            List<Order> orders = adminService.GetOrders(0);

            foreach (Order order in orders)
            {
                long quantity = order.unfilledQuantity;
                decimal price = order.price;

                if (quantity > 0)
                {
                    if (order.buySell == BuySell.Buy)
                    {
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

            List<Trade> trades = adminService.GetTrades(0);

            decimal totalPrice = 0;
            long totalQuantity = 0;
            foreach (Trade trade in trades)
            {
                totalPrice += trade.executionPrice * trade.quantity;
                totalQuantity += trade.quantity;
            }

            if (totalQuantity > 0)
            {
                previousPrice = totalPrice / totalQuantity;
            }

            if (previousPrice > 0)
            {
                System.Windows.Forms.DataVisualization.Charting.Series priceSeries = chart2.Series[0];
                priceSeries.Points.AddXY(time, previousPrice);

                System.Windows.Forms.DataVisualization.Charting.Series volumeSeries = chart3.Series[0];
                volumeSeries.Points.AddXY(time++, totalQuantity);
            }
        }

        protected class Refresher
        {
            AdminForm form;

            public Refresher(AdminForm form)
            {
                this.form = form;
            }

            public void Start()
            {
                Thread.Sleep(1000);
                while (AdminForm.active)
                {
                    form.Invoke(new MethodInvoker(() => Refresh()));
                    Thread.Sleep(5000);
                }
            }

            public void Refresh()
            {
                form.RefreshCharts();
            }

        }

    }
}
