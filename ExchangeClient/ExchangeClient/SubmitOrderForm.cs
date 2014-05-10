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

namespace OrderClient
{
    public partial class SubmitOrderForm : Form
    {
        public SubmitOrderForm()
        {
            InitializeComponent();
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

    }
}
