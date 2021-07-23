using Microsoft.AspNetCore.Mvc;
using StoreDL;
using StoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Controllers
{
    public class InventoryItemController : Controller
    {
        private ISQLDatastore _datastore;
        public InventoryItemController(ISQLDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public IActionResult Index(int p_id)
        {
            return View(_datastore.GetStoreInventory(p_id)
                .Select(item => new InventoryItemVM(item)).OrderBy(item => item.Prod.Name).ToList());
        }
    }
}
