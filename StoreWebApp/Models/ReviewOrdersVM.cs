using StoreClasslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class ReviewOrdersVM
    {
        public string ItemName { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public decimal LineTotal { set; get; }
        public int OrderId { set; get; }

        public ReviewOrdersVM(LineItem p_item)
        {
            ItemName = p_item.Prod.Name;
            Price = p_item.Prod.Price;
            Quantity = p_item.Quantity;
            LineTotal = p_item.Prod.Price * Quantity;
            OrderId = p_item.OrderId;
        }

        public ReviewOrdersVM()
        { }
    }
}
