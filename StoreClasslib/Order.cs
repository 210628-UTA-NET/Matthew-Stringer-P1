using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClasslib
{
    public class Order
    {
        public int Id { set; get; }
        public List<Order> LineItems { set; get; }

        public string Location { set; get; }

        public decimal TotalPrice { set; get; }

        public int CustomerId { set; get; }

        public int StoreFrontId { set; get; }

        public Order()
        {
            this.LineItems = new List<Order>();
            this.TotalPrice = 0;
        }
    }
}
