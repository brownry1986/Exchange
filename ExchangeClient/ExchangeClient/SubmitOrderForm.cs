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
	/*
	 * Form object for the UI for the exchange client
     * 
     * Implemented by Ryan Brown
     * Business requirements for GUI determined by discussions with entire team
	 */
    public partial class SubmitOrderForm : Form
    {

        protected static Boolean refresh = false;

        protected static Boolean active = true;

        /*
         * Initialize UI form and startup thread for refreshing order list and trade list
         * 
         * Implemented by Ryan Brown
         */
        public SubmitOrderForm()
        {
            InitializeComponent();
            Refresher refresher = new Refresher(this);
            Thread refresherThread = new Thread(refresher.Start);
            refresherThread.Start();
        }

        /*
         * Upon clicking the submit button, pull the data from the user to create and Order and call the Order Service to submit the order
         * 
         * Implemented by Ryan Brown
         */
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

            ServiceLibrary.IOrderService orderService = new ServiceLibrary.OrderService();
            Order submittedOrder = orderService.SubmitOrder(order);

            refreshOrders();
        }

        /*
         * Retrieve the list of active orders from the Order Service and display in the UI
         * 
         * Implemented by Ryan Brown
         */
        protected void refreshOrders()
        {
            Int64 traderId = Convert.ToInt64(traderBox.SelectedValue);
            Int64 productId = Convert.ToInt64(productBox.SelectedValue);
            ServiceLibrary.IOrderService orderService = new ServiceLibrary.OrderService();
            List<Order> orders = orderService.GetOrders(productId, traderId);
            orderDataGridView.DataSource = orders;
        }

        /*
         * Retrieve the list of matched trades from the Order Service and display in the UI
         * 
         * Implemented by Ryan Brown
         */
        private void refreshTrades()
        {
            Int64 traderId = Convert.ToInt64(traderBox.SelectedValue);
            Int64 productId = Convert.ToInt64(productBox.SelectedValue);
            ServiceLibrary.IOrderService orderService = new ServiceLibrary.OrderService();
            List<Trade> trades = orderService.GetTrades(productId, traderId);
            tradeDataGridView.DataSource = trades;
        }

        /*
         * Retrieve the bid/ask prices for the selected product and display in the UI
         * 
         * Implemented by Ryan Brown
         */
        private void refreshProductInformation()
        {
            ServiceLibrary.IOrderService orderService = new ServiceLibrary.OrderService();
            BidAsk bidAsk = orderService.GetBidAsk(Convert.ToInt64(productBox.SelectedValue));
            bidPriceBox.Text = bidAsk.getBidPriceValue();
            askPriceBox.Text = bidAsk.getAskPriceValue();
        }

        /*
         * Upon selection of the trader, lock down the trader drop down and display the product selection box
         * 
         * Implemented by Ryan Brown
         */
        private void traderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            traderBox.Enabled = false;
            product.Visible = true;
            productBox.Visible = true;
        }

        /*
         * Upon selection of the product, retrieve and display the product information, active orders, and matched trades for the selected product
         * 
         * Implemented by Ryan Brown
         */
        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean display = (productBox.SelectedIndex > 0);
            productGroupBox.Visible = display;
            submitOrderGroupBox.Visible = display;
            activeOrderGroupBox.Visible = display;
            executedTradesGroupBox.Visible = display;

            if (display)
            {
                refreshOrders();
                refreshTrades();
                refreshProductInformation();
            }

            SubmitOrderForm.refresh = display;
        }

        /*
         * Upon selection of the order type, if the order type is a Market Order hide the price box
         * 
         * Implemented by Ryan Brown
         */
        private void orderTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.orderTypeBox.SelectedIndex == 0)
            {
                this.priceLabel.Visible = false;
                this.priceValue.Visible = false;
            }
            else
            {
                this.priceLabel.Visible = true;
                this.priceValue.Visible = true;
            }
        }

        /*
         * Upon closing the form, set the form as inactive so that other threads will know to shut down
         * 
         * Implemented by Ryan Brown
         */
        private void form_Close(object sender, EventArgs e)
        {
            SubmitOrderForm.active = false;
        }

        /*
         * Class to periodically refresh the product, order, and trade information
         * 
         * Implemented by Ryan Brown
         */
        protected class Refresher
        {
            SubmitOrderForm form;

            public Refresher(SubmitOrderForm form)
            {
                this.form = form;
            }

            /*
             * Once the Exchange Client form is active and the refresh flag is set, refresh the data on the form every 5 seconds
             * 
             * Implemented by Ryan Brown
             */
            public void Start()
            {
                while (SubmitOrderForm.active)
                {
                    if (SubmitOrderForm.refresh)
                    {
                        form.Invoke(new MethodInvoker(() => Refresh()));
                    }
                    Thread.Sleep(5000);
                }
            }

            /*
             * Refresh orders, trades, and product information
             * 
             * Implemented by Ryan Brown
             */
            public void Refresh()
            {
                form.refreshOrders();
                form.refreshTrades();
                form.refreshProductInformation();
            }
        }
    }
}
