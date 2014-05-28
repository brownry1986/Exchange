using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace ExchangeClient
{
    public partial class SubmitOrderForm : Form
    {

        public SubmitOrderForm()
        {
            InitializeComponent();
        }

        private void SubmitOrderForm_Load(object sender, EventArgs e)
        {
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            Order order = new Order();
            order.traderId = Convert.ToInt64(traderBox.SelectedValue);
            order.productId = Convert.ToInt64(productBox.SelectedValue);
            order.buySell = (BuySell) buySellBox.SelectedItem;
            order.orderType = (OrderType)orderTypeBox.SelectedItem;
            order.quantity = Convert.ToInt64(quantityValue.Text);
            order.price = Convert.ToDecimal(priceValue.Text);

            ServiceLibrary.OrderService orderService = new ServiceLibrary.OrderService();
            Order submittedOrder = orderService.SubmitOrder(order);
            System.Console.WriteLine("Order Submission Successful: Order Number = " + submittedOrder.orderNumber);
            refreshOrders();
            //orderService.CancelOrder(1234, submittedOrder.orderNumber);
            //System.Console.WriteLine("Order Cancellation Successful: Order Number = " + submittedOrder.orderNumber);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Refresh Button Clicked");
            refreshOrders();
        }

        private void refreshOrders()
        {
            Int64 traderId = Convert.ToInt64(traderBox.SelectedValue);
            Int64 productId = Convert.ToInt64(productBox.SelectedValue);
            OrderService.IOrderService service = new OrderService.OrderServiceClient();
            List<Order> orders = service.GetOrders(traderId, productId);

            foreach (Order order in orders)
            {
                Console.WriteLine("Received Order: {0}", order.ToString());
            }
            orderDataGridView1.DataSource = orders;
        }

        private void traderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            traderBox.Enabled = false;
            product.Visible = true;
            productBox.Visible = true;
            refreshOrders();
            //refreshTrades();
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean display = (productBox.SelectedIndex > 0);
            productGroupBox.Visible = display;
            orderGroupBox.Visible = display;
            executedTradesGroupBox.Visible = display;
            refreshOrders();
            //refreshTrades();
        }
    }
}
