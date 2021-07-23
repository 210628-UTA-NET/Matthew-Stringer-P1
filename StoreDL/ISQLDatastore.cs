using StoreClasslib;
using System.Collections.Generic;

namespace StoreDL
{
    public interface ISQLDatastore
    {
        void AddCustomer(Customer p_cust);
        List<Customer> SearchCustomerByName(string p_name);
        List<StoreFront> SearchStoreFrontByName(string p_name);
        List<Customer> GetAllCustomers();
        List<StoreFront> GetAllStoreFronts();
        List<InventoryItem> GetStoreInventory(int p_id);
    }
}