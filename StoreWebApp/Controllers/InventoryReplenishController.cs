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
            Log.Information($"p_changes.count == {p_changes.Count}");
            if(_datastore.SaveStoreInventoryChanges(p_changes.Where(change => change.NewQuant > 0).Select(change => new InventoryItem
            {
                Id = change.Id,
                StoreFrontId = change.StoreId,
                Prod = change.Prod,
                Quantity = change.NewQuant + change.QuantNow
            }).ToList()))
            {
                Log.Information("Inventory save successful.");
            }
            else
            {
                Log.Error("Inventory save failed.");
            }
            return Redirect("/");
        }
    }
}
