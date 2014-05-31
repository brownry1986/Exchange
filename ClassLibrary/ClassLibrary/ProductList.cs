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
            products.Add(new Product(-1, "", "", ""));
            products.Add(new Product(0, "Mid-Ag-A", "Midwest Agricultural", "A"));
            products.Add(new Product(1, "Mid-Ag-B", "Midwest Agricultural", "B"));
            products.Add(new Product(2, "Mid-Ag-C", "Midwest Agricultural", "C"));
            products.Add(new Product(3, "Mid-Ag-D", "Midwest Agricultural", "D"));
            products.Add(new Product(4, "Mid-Ind-A", "Midwest Industrial", "A"));
            products.Add(new Product(5, "Mid-Ind-B", "Midwest Industrial", "B"));
            products.Add(new Product(6, "Mid-Ind-C", "Midwest Industrial", "C"));
            products.Add(new Product(7, "Mid-Ind-D", "Midwest Industrial", "D"));
            products.Add(new Product(8, "Cal-Ag-A", "California Agricultural", "A"));
            products.Add(new Product(9, "Cal-Ag-B", "California Agricultural", "B"));
            products.Add(new Product(10, "Cal-Ag-C", "California Agricultural", "C"));
            products.Add(new Product(11, "Cal-Ag-D", "California Agricultural", "D"));
            products.Add(new Product(12, "Cal-Tech-A", "California Technical", "A"));
            products.Add(new Product(13, "Cal-Tech-B", "California Technical", "B"));
            products.Add(new Product(14, "Cal-Tech-C", "California Technical", "C"));
            products.Add(new Product(15, "Cal-Tech-D", "California Technical", "D"));
        }
    }
}
