using StoreClasslib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Models
{
    public class LineItemVM
    {
        public LineItemVM()
        { }

        public int Id { set; get; }
        public Product Prod { set; get; }
        public int Quantity { set; get; }

    }
}
