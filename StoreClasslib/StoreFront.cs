using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClasslib
{
    public class StoreFront
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public string Address { set; get; }

        public List<LineItem> Inventory { set; get; }

        public List<Order> Orders { set; get; }

        public StoreFront()
        {
            this.Inventory = new List<LineItem>();
            this.Orders = new List<Order>();
        }
    }
}
