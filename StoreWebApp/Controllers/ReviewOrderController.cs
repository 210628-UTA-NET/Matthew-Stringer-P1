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
            List<ReviewOrdersVM> itemList = new();
            foreach(Order order in orderList)
            {
                foreach(LineItem item in order.LineItems.OrderBy(x => x.Prod.Name))
                {
                    itemList.Add(new ReviewOrdersVM(order, item));
                }
            }
            return View(itemList);
        }
    }
}
