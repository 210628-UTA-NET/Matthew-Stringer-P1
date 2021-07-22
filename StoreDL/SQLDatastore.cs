using System.Collections.Generic;
using System.Linq;
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

        //public bool SaveOrder(Order p_order, List<p0class.LineItem> p_modified)
        //{
        //    _context.Database.BeginTransaction();
        //    Entities.Order newRow = new Entities.Order
        //        {
        //            OLoc = p_order.Location,
        //            OCust = p_order.CustomerId,
        //            OStore = p_order.StoreFrontId
        //        };
        //    _context.Add(newRow);
        //    _context.SaveChanges();
        //    foreach (p0class.LineItem item in p_order.LineItems)
        //    {
        //        _context.Add(new Entities.LineItem
        //            {
        //                LOrder = newRow.OId,
        //                LProd = item.Prod.Id,
        //                LQuantity = item.Quantity
        //            });
        //    }
        //    foreach (p0class.LineItem item in p_modified)
        //    {
        //        if (item.Quantity == 0)
        //        {
        //            _context.Remove(_context.LineItems.Single(x => x.LId == item.Id));
        //        }
        //        else
        //        {
        //            Entities.LineItem updateRow = _context.Find<Entities.LineItem>(item.Id);
        //            updateRow.LQuantity = item.Quantity;
        //        }
        //    }
        //    _context.SaveChanges();
        //    _context.Database.CommitTransaction();
        //    return true;
        //}

        //public List<Product> GetAllProducts()
        //{
        //    List<Product> result = new List<Product>();

        //    foreach (var prod in _context.Products.ToList<Entities.Product>())
        //    {
        //        result.Add(new Product
        //            {
        //                Id = prod.PId,
        //                Name = prod.PName,
        //                Price = prod.PPrice,
        //                Description = prod.PDesc,
        //                Category = prod.PCategory
        //            });
        //    }
        //    return result;
        //}

        //public bool UpdateOrAddInventory(int p_store, int p_prod, int p_quantity)
        //{
        //    Entities.LineItem item = _context.LineItems.Select(l => l)
        //        .Where(l => l.LStorefront == p_store && l.LProd == p_prod).SingleOrDefault();

        //    if (item == null)
        //    {
        //        _context.LineItems.Add(new Entities.LineItem
        //            {
        //                LStorefront = p_store,
        //                LProd = p_prod,
        //                LQuantity = p_quantity
        //            });
        //    }
        //    else
        //    {
        //        item.LQuantity += p_quantity;
        //    }

        //    _context.SaveChanges();

        //    return true;
        //}
    }
}