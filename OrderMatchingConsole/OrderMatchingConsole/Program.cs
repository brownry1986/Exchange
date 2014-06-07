using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMatchingLibrary;

namespace OrderMatchingService
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderMatchingEngine orderMatchingEngine = new OrderMatchingEngine();
            orderMatchingEngine.Start();
        }
    }
}
