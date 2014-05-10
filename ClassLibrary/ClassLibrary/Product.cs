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
        public virtual long productId { get; set; }

        public virtual String productName { get; set; }

    }
}
