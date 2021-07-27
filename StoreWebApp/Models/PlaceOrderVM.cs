using StoreClasslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class PlaceOrderVM
    {
        public Product Prod { set; get; }
        public int StoreId { set; get; }
        public int CustId { set; get; }
        public int Available { set; get; }
        public int Ordered { set; get; }

        public PlaceOrderVM(int p_store, int p_cust, InventoryItem p_inventory)
        {
            StoreId = p_store;
            CustId = p_cust;
            Prod = p_inventory.Prod;
            Available = p_inventory.Quantity;
            Ordered = 0;
        }
    }
}
