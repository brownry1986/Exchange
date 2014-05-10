using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Account
    {
        public virtual long traderId { get; set; }

        public virtual Dictionary<String, long> holdings { get; set; }

        public virtual decimal balance { get; set; }
    }
}
