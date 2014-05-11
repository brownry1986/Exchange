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
            Console.WriteLine("Loading Form");
            OrderService.IOrderService service = new OrderService.OrderServiceClient();
            List<Order> orders = service.GetOrders(0);

            foreach (Order order in orders)
            {
                Console.WriteLine("Received Order: {0}", order.ToString());
            }

            orderDataGridView1.DataSource = orders;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            String product = productValue.Text;
            Order order = new Order();
            order.productId = Convert.ToInt64(productValue.Text);
            order.quantity = Convert.ToInt64(quantityValue.Text);
            order.price = Convert.ToDecimal(priceValue.Text);

            ServiceLibrary.OrderService orderService = new ServiceLibrary.OrderService();
            Order submittedOrder = orderService.SubmitOrder(order);
            System.Console.WriteLine("Order Submission Successful: Order Number = " + submittedOrder.orderNumber);
            orderService.CancelOrder(1234, submittedOrder.orderNumber);
            System.Console.WriteLine("Order Cancellation Successful: Order Number = " + submittedOrder.orderNumber);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Refresh Button Clicked");

            //ServiceLibrary.OrderService orderService = new ServiceLibrary.OrderService();
            //List<Order> orders = orderService.GetOrders(0);

            //OrderServiceReference.IOrderService service = new OrderServiceReference.OrderServiceClient();
            //Order[] myOrders = service.GetOrders(0);

            OrderService.IOrderService service = new OrderService.OrderServiceClient();
            List<Order> orders = service.GetOrders(0);

            foreach (Order order in orders)
            {
                Console.WriteLine("Received Order: {0}", order.ToString());
            }
            orderDataGridView1.DataSource = orders;
        }

    }
}
