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
    }
}
