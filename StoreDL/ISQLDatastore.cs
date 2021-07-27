﻿using StoreClasslib;
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
        Customer GetCustomerById(int p_id);
        StoreFront GetStoreFrontById(int p_id);
    }
}