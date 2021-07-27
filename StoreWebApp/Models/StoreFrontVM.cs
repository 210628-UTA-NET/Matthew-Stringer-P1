using StoreClasslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class StoreFrontVM
    {
        public StoreFrontVM()
        { }

        public StoreFrontVM(StoreFront p_store, int p_cust_id = 0)
        {
            StoreFrontId = p_store.StoreFrontId;
            Name = p_store.Name;
            Address = p_store.Address;
            CustomerId = p_cust_id;
        }

        public int StoreFrontId { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public int CustomerId { set; get; } // Optional - only to pass along to the Place Order interface
    }
}
