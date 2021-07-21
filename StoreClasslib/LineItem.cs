using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClasslib
{
    public class LineItem
    {
        [Key]
        public int Id { set; get; }
        public Product Prod { set; get; }
        public int Quantity { set; get; }
        [ForeignKey("Order")]
        public int OrderId { set; get; }
        public Order Order { set; get; }
    }
}
