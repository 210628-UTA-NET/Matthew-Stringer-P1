using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClasslib
{
    public class StoreFront
    {
        [Key]
        public int StoreFrontId { set; get; }
        public string Name { set; get; }

        public string Address { set; get; }

        public List<InventoryItem> Inventory { set; get; }

        public List<Order> Orders { set; get; }

        public StoreFront()
        {
            this.Inventory = new List<InventoryItem>();
            this.Orders = new List<Order>();
        }
    }
}
