using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Product
    {
        public Product(Int64 productId, String name) 
        {
            this.productId = productId;
            this.name = name;
        }

        public Int64 productId { get; set; }

        public String name { get; set; }

    }
}
