using StoreClasslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class InventoryItemVM
    {
        public InventoryItemVM()
        { }

        public InventoryItemVM(InventoryItem p_item)
        {
            Id = p_item.Id;
            Prod = p_item.Prod;
            Quantity = p_item.Quantity;
            StoreFrontId = p_item.StoreFrontId;
        }

        public int Id { set; get; }
        public Product Prod { set; get; }
        public int Quantity { set; get; }
        public int StoreFrontId { set; get; }

    }
}
