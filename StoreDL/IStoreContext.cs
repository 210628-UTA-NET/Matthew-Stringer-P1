using Microsoft.EntityFrameworkCore;
using StoreClasslib;

namespace StoreDL
{
    public interface IStoreContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<InventoryItem> InventoryItems { get; set; }
        DbSet<LineItem> LineItems { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<StoreFront> StoreFronts { get; set; }
    }
}