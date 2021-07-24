using StoreClasslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class InventoryReplenishVM
    {
        public InventoryReplenishVM(InventoryItem p_item)
        {
            Id = p_item.Id;
            StoreId = p_item.StoreFrontId;
            Prod = p_item.Prod;
            QuantNow = p_item.Quantity;
            NewQuant = 0;
        }

        public int Id { set; get; }
        public int StoreId { get; set; }
        public Product Prod { set; get; }
        public int QuantNow { set; get; }
        public int NewQuant { set; get; }
    }
}
