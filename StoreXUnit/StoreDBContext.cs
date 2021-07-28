// Adapted from https://www.c-sharpcorner.com/article/unit-testing-with-inmemory-provider-and-sqlite-in-memory-database-in-efcore/
using System;
using Microsoft.EntityFrameworkCore;
using StoreClasslib;

namespace StoreXUnit
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        { }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

    }
}
