using Microsoft.AspNetCore.Mvc;
using StoreClasslib;
using StoreDL;
using StoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private ISQLDatastore _datastore;

        public CustomerController(ISQLDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public IActionResult Index()
        {
            return View(_datastore.GetAllCustomers()
                .Select(cust => new CustomerVM(cust)).ToList());
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerVM restVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _datastore.AddCustomer(new Customer
                    {
                        Name = restVM.Name,
                        Address = restVM.Address,
                        Email = restVM.Email
                    }
                    );

                    return RedirectToAction(nameof(Index)); //Go back to the index html of the Customer Controller
                }
            }
            catch (Exception)
            {
                return View();
            }

            return View();
        }
    }
}
