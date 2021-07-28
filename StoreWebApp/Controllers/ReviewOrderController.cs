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

        private List<ReviewOrdersVM> SerializeResults(List<Order> p_orders, bool p_date)
        {
            List<ReviewOrdersVM> itemList = new();
            foreach (Order order in p_orders)
            {
                foreach (LineItem item in order.LineItems)
                {
                    itemList.Add(new ReviewOrdersVM(order, item, p_date));
                }
            }
            return itemList;
        }

        public IActionResult Index(int p_id, bool p_cust)
        {
            return View(new ReviewOptionsVM
            {
                Id = p_id,
                Cust = p_cust
            });
        }

        [HttpPost]
        public IActionResult MakeReport(int p_id, bool p_cust, bool p_date, bool p_ascending)
        {
            Log.Information($"p_id {p_id}\tp_cust {p_cust}\tp_date {p_date}\tp_ascending {p_ascending}");
            List<Order> orderList = p_cust ? _datastore.GetCustomerOrderHistory(p_id) : _datastore.GetStoreOrderHistory(p_id);
            List<ReviewOrdersVM> itemList = SerializeResults(orderList, p_date);
            if (p_date)
            {
                return View(p_ascending ? itemList.OrderBy(x => x.OrderTime).ThenBy(x => x.OrderId).ThenBy(x => x.ItemName).ToList() :
                    itemList.OrderByDescending(x => x.OrderTime).ThenBy(x => x.ItemName).ToList());
            }
            return View(p_ascending ? itemList.OrderBy(x => x.LineTotal).ThenBy(x => x.ItemName).ToList() :
                itemList.OrderByDescending(x => x.LineTotal).ThenBy(x => x.ItemName).ToList());
        }
    }
}
