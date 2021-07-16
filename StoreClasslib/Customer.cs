using System;
using System.Collections.Generic;

namespace StoreClasslib
{
    public class Customer
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public string Address { set; get; }

        public string Email { set; get; }

        public List<Order> Orders { set; get; }

        public Customer()
        {
            this.Orders = new List<Order>();
        }
    }
}
