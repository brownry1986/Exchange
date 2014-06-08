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

        /*
         * When the service is started, kick-off the order matching engine
         * 
         * Implemented by Ryan Brown
         */
        protected override void OnStart(string[] args)
        {
            orderMatchingEngine.Start();
        }

        /*
         * When the service is stopped, call the Stop method in the order matching engine to gracefully shut it down
         * 
         * Implemented by Ryan Brown
         */
        protected override void OnStop()
        {
            orderMatchingEngine.Stop();
        }
    }
}
