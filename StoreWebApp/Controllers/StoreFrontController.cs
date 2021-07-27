using Microsoft.AspNetCore.Mvc;
using StoreDL;
using StoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Controllers
{
    public class StoreFrontController : Controller
    {
        private ISQLDatastore _datastore;
        public StoreFrontController(ISQLDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public IActionResult Index()
        {
            return View(_datastore.GetAllStoreFronts()
                .Select(store => new StoreFrontVM(store)).OrderBy(store => store.Name).ThenBy(store => store.Address).ToList());
        }

        public IActionResult SelectForOrder(int p_cust_id)
        {
            return View(_datastore.GetAllStoreFronts()
                .Select(store => new StoreFrontVM(store, p_cust_id)).OrderBy(store => store.Name).ThenBy(store => store.Address).ToList());
        }
    }
}
