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

namespace ExchangeClient
{
    public partial class SubmitOrderForm : Form
    {

        protected static Boolean refresh = false;

        protected static Boolean active = true;

        public SubmitOrderForm()
        {
            InitializeComponent();
            Refresher refresher = new Refresher(this);
            Thread refresherThread = new Thread(refresher.Start);
            refresherThread.Start();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.traderId = Convert.ToInt64(traderBox.SelectedValue);
            order.productId = Convert.ToInt64(productBox.SelectedValue);
            order.buySell = (BuySell) buySellBox.SelectedItem;
            order.orderType = (OrderType)orderTypeBox.SelectedItem;
            order.quantity = Convert.ToInt64(quantityValue.Text);
            order.filledQuantity = Convert.ToInt64(0);
            order.price = order.orderType == OrderType.Limit ? Convert.ToDecimal(priceValue.Text) : Convert.ToDecimal(0);

            ServiceLibrary.OrderService orderService = new ServiceLibrary.OrderService();
            Order submittedOrder = orderService.SubmitOrder(order);
            refreshOrders();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshOrders();
        }

        protected void refreshOrders()
        {
            Int64 traderId = Convert.ToInt64(traderBox.SelectedValue);
            Int64 productId = Convert.ToInt64(productBox.SelectedValue);
            OrderService.IOrderService service = new OrderService.OrderServiceClient();
            List<Order> orders = service.GetOrders(productId, traderId);

            foreach (Order order in orders)
            {
                Console.WriteLine("Received Order: {0}", order.ToString());
            }
            orderDataGridView.DataSource = orders;
        }

        private void refreshTrades()
        {
            Int64 traderId = Convert.ToInt64(traderBox.SelectedValue);
            Int64 productId = Convert.ToInt64(productBox.SelectedValue);
            OrderService.IOrderService service = new OrderService.OrderServiceClient();

            List<Trade> trades = service.GetTrades(productId, traderId);

            foreach (Trade trade in trades)
            {
                Console.WriteLine("Received Trade: {0}", trade.ToString());
            }

            tradeDataGridView.DataSource = trades;
        }

        private void refreshProductInformation()
        {
            OrderService.IOrderService service = new OrderService.OrderServiceClient();
            Tuple<String, String> bidAsk = service.GetBidAsk(Convert.ToInt64(productBox.SelectedValue));
            bidPriceBox.Text = bidAsk.Item1;
            askPriceBox.Text = bidAsk.Item2;
        }

        private void traderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            traderBox.Enabled = false;
            product.Visible = true;
            productBox.Visible = true;
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean display = (productBox.SelectedIndex > 0);
            productGroupBox.Visible = display;
            orderGroupBox.Visible = display;
            executedTradesGroupBox.Visible = display;

            if (display)
            {
                refreshOrders();
                refreshTrades();
                refreshProductInformation();
            }

            SubmitOrderForm.refresh = display;
        }

        private void form_Close(object sender, EventArgs e)
        {
            SubmitOrderForm.active = false;
        }

        protected class Refresher
        {
            SubmitOrderForm form;

            public Refresher(SubmitOrderForm form)
            {
                this.form = form;
            }

            public void Start()
            {
                while (SubmitOrderForm.active)
                {
                    if (SubmitOrderForm.refresh)
                    {
                        form.Invoke(new MethodInvoker(() => Refresh()));
                    }
                    Thread.Sleep(2000);
                }
            }

            public void Refresh()
            {
                form.refreshOrders();
                form.refreshTrades();
                form.refreshProductInformation();
            }

        }
    }
}
