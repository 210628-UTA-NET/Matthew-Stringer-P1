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
        public DateTime OrderTime { set; get; }
        public bool OrderByDate { set; get; }
        public ReviewOrdersVM(Order p_order, LineItem p_item, bool p_byDate)
        {
            ItemName = p_item.Prod.Name;
            Price = p_item.Prod.Price;
            Quantity = p_item.Quantity;
            LineTotal = p_item.Prod.Price * Quantity;
            OrderId = p_order.OrderId;
            OrderTime = p_order.DateAdded;
            OrderByDate = p_byDate;
        }

        public ReviewOrdersVM()
        { }
    }
}
