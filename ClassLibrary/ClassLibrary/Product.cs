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
        public Product(Int64 productId, String name, String description, String rating) 
        {
            this.productId = productId;
            this.name = name;
            this.description = description;
            this.rating = rating;
        }

        public Int64 productId { get; set; }

        public String name { get; set; }

        public String description { get; set; }

        public String rating { get; set; }

    }
}
