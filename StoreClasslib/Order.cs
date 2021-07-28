using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClasslib
{
    public class Order
    {
        [Key]
        public int OrderId { set; get; }

        public List<LineItem> LineItems { set; get; }

        public string Location { set; get; }

        [ForeignKey("Customer ")]
        public int CustomerId { set; get; }

        [ForeignKey("StoreFront ")]
        public int StoreFrontId { set; get; }

        public DateTime DateAdded { set; get; }

        public Order()
        {
            this.LineItems = new List<LineItem>();
        }
    }
}
