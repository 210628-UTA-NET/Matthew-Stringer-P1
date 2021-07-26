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
            List<InventoryItem> changingStores = p_changes.Where(change => change.NewQuant > 0).Select(change => new InventoryItem
            {
                Id = change.Id,
                StoreFrontId = change.StoreId,
                Prod = change.Prod,
                Quantity = change.NewQuant + change.QuantNow
            }).ToList();

            if (changingStores.Count > 0)
            {
                if (_datastore.SaveStoreInventoryChanges(changingStores))
                {
                    Log.Information("Inventory save successful.");
                    return Redirect($"/InventoryItem?p_id={changingStores[0].StoreFrontId}");
                }
                else
                {
                    Log.Error("Inventory save failed.");
                    return Redirect("/");
                }
            }
            return Redirect("/");
        }
    }
}
