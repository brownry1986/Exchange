using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class ProductList
    {

        public static List<Product> products = new List<Product>();

        static ProductList()
        {
            products.Add(new Product(-1, ""));
            products.Add(new Product(0, "Midwest Agricultural"));
            products.Add(new Product(1, "Midwest Industrial"));
            products.Add(new Product(2, "Midwest Technical"));
            products.Add(new Product(3, "Midwest Northeast Manufacturing"));
            products.Add(new Product(4, "California Agricultural"));
            products.Add(new Product(5, "California Technical"));
        }
    }
}
