using Microsoft.AspNetCore.Mvc;
using StoreDL;
using StoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace StoreWebApp.Controllers
{
    public class InventoryReplenishController : Controller
    {
        private ISQLDatastore _datastore;
        public InventoryReplenishController(ISQLDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public IActionResult Index(int p_id)
        {
            return View(_datastore.GetStoreInventoryWithZeroes(p_id)
                .Select(item => new InventoryReplenishVM(item)).OrderBy(item => item.Prod.Name).ToList());
        }

        public IActionResult ReviewChanges(ICollection<InventoryReplenishVM> p_changes)
        {
            return View(p_changes);
        }

        public RedirectResult SaveChanges(ICollection<InventoryReplenishVM> p_changes)
        {
            return Redirect("/");
        }
    }
}
