using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StoreClasslib;

namespace StoreDL
{
    public class SQLDatastore : ISQLDatastore
    {
        private StoreContext _context;
        public SQLDatastore(StoreContext p_context)
        {
            _context = p_context;
        }

        public void AddCustomer(Customer p_cust)
        {
            _context.Customers.Add(p_cust);

            _context.SaveChanges();
        }

        public List<Customer> SearchCustomerByName(string p_name)
        {
            return _context.Customers.Select(cust => cust).Where(x => x.Name.Contains(p_name)).ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }


        public List<StoreFront> SearchStoreFrontByName(string p_name)
        {
            return _context.StoreFronts.Select(store => store).Where(x => x.Name.Contains(p_name)).ToList();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(store => store).ToList();
        }

        public List<InventoryItem> GetStoreInventory(int p_id)
        {
            return _context.InventoryItems.Where(item => item.StoreFrontId == p_id).Include(item => item.Prod).ToList();
        }

        public List<InventoryItem> GetStoreInventoryWithZeroes(int p_id)
        {
            Dictionary<int, InventoryItem> dict = new Dictionary<int, InventoryItem>();
            foreach (Product prod in _context.Products.ToList())
            {
                dict.Add(prod.Id, new InventoryItem
                {
                    Id = 0,
                    Prod = prod,
                    StoreFrontId = p_id,
                    Quantity = 0
                });
            }
            foreach (InventoryItem item in _context.InventoryItems.Where(item => item.StoreFrontId == p_id).Include(item => item.Prod).ToList())
            {
                InventoryItem itemOut = dict[item.Prod.Id];
                itemOut.Id = item.Id;
                itemOut.Quantity = item.Quantity;
            }
            return dict.Values.ToList();
        }

        public bool SaveStoreInventoryChanges(List<InventoryItem> p_changes)
        {
            try
            {
                _context.Database.BeginTransaction();
                foreach (InventoryItem change in p_changes)
                {
                    _context.Entry(change).State = change.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
                _context.SaveChanges();
                _context.Database.CommitTransaction();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool PlaceOrder(Order p_new_order, List<InventoryItem> p_sold_out)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.Orders.Add(p_new_order);
                foreach (InventoryItem item in p_sold_out)
                {
                    _context.InventoryItems.Remove(item);
                }
                _context.SaveChanges();
                _context.Database.CommitTransaction();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Order> GetCustomerOrderHistory(int p_id)
        {
            Customer cust = _context.Customers.Where(x => x.Id == p_id).Include(x => x.Orders).ThenInclude(x => x.LineItems).ThenInclude(x => x.Prod).First();

            return cust.Orders;
        }
    }
}