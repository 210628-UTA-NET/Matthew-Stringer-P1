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
        List<InventoryItem> GetStoreInventoryWithZeroes(int p_id);
        bool SaveStoreInventoryChanges(List<InventoryItem> p_changes);
        bool PlaceOrder(Order p_new_order, List<InventoryItem> p_sold_out);
    }
}