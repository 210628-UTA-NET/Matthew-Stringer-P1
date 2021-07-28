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
    public class PlaceOrderController : Controller
    {
        private ISQLDatastore _datastore;

        public PlaceOrderController(ISQLDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public IActionResult Index(int p_cust_id, int p_store_id)
        {
            return View(_datastore.GetStoreInventory(p_store_id).OrderBy(item => item.Prod.Name).Select(item => new PlaceOrderVM(p_store_id, p_cust_id, item)).ToList());
        }

        public IActionResult ReviewChanges(IEnumerable<PlaceOrderVM> p_data)
        {
            return View(p_data);
        }

        public RedirectResult SaveChanges(IEnumerable<PlaceOrderVM> p_data)
        {
            if (p_data.Count() == 0)
            {
                return Redirect("/");
            }

            Order newOrder = new();
            newOrder.DateAdded = DateTime.Now;
            PlaceOrderVM firstItem = p_data.First();
            newOrder.CustomerId = firstItem.CustId;
            newOrder.StoreFrontId = firstItem.StoreId;
            List<InventoryItem> inventory = _datastore.GetStoreInventory(firstItem.StoreId);
            List<InventoryItem> soldOut = new();
            foreach (PlaceOrderVM change in p_data)
            {
                InventoryItem item = inventory.Where(x => x.Prod.Id == change.Prod.Id).First();
                if (change.Ordered > change.Available || change.Ordered > item.Quantity)
                {
                    return Redirect("/");
                }
                if (change.Ordered > 0)
                {
                    newOrder.LineItems.Add(new LineItem
                    {
                        Prod = item.Prod,
                        Order = newOrder,
                        Quantity = change.Ordered
                    });
                    if (item.Quantity == change.Ordered)
                    {
                        soldOut.Add(item);
                    }
                    else
                    {
                        item.Quantity -= change.Ordered;
                    }
                }
            }
            if (_datastore.PlaceOrder(newOrder, soldOut))
            {
                Log.Information("Save returned true");
            }
            else
            {
                Log.Information("Save returned false");
            }
            return Redirect("/");
        }

    }
}
