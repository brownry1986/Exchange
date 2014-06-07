using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OrderMatchingLibrary;

namespace OrderMatchingService
{
    public partial class OrderMatchingService : ServiceBase
    {
        OrderMatchingEngine orderMatchingEngine = new OrderMatchingEngine();

        public OrderMatchingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            orderMatchingEngine.Start();
        }

        protected override void OnStop()
        {
            orderMatchingEngine.Stop();
        }
    }
}
