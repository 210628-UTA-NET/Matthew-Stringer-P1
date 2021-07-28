using Microsoft.AspNetCore.Mvc;
using StoreDL;
using StoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using StoreClasslib;

namespace StoreWebApp.Controllers
{
    public class ReviewOrderController : Controller
    {
        private ISQLDatastore _datastore;
        public ReviewOrderController(ISQLDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public IActionResult Index(int p_id)
        {
            List<Order> orderList = _datastore.GetCustomerOrderHistory(p_id).OrderBy(x => x.DateAdded).ToList();
            List<LineItem> itemList = new();
            foreach(Order order in orderList)
            {
                itemList.AddRange(order.LineItems);
            }
            return View(itemList.Select(x => new ReviewOrdersVM(x)).OrderBy(x => x.ItemName).ToList());
        }
    }
}
