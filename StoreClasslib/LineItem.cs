using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClasslib
{
    public class LineItem
    {
        public int Id { set; get; }
        public Product Prod { set; get; }
        public int Quantity { set; get; }
    }
}
