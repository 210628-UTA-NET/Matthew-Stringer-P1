using Microsoft.EntityFrameworkCore;
using StoreClasslib;
using System;
using System.Collections.Generic;

namespace StoreDL
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext() : base()
        { }

        public StoreContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<StoreFront> StoreFronts { get; set; }

        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        {
            p_options.UseNpgsql(@"Server=batyr.db.elephantsql.com;Database=moaualdq;User Id=moaualdq;Password=Jn2Z94Le1pwLHC-pJwaWSxBXQC7iXpQd");
        }

        //protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        //{
        //    //It will auto generate the ID column for both tables

        //    p_modelBuilder.Entity<Customer>()
        //        .Property(cust =>  cust.Id)
        //        .ValueGeneratedOnAdd();

        //    p_modelBuilder.Entity<LineItem>()
        //        .Property(item => item.Id)
        //        .ValueGeneratedOnAdd();

        //    p_modelBuilder.Entity<Order>()
        //        .Property(order => order.Id)
        //        .ValueGeneratedOnAdd();

        //    p_modelBuilder.Entity<Product>()
        //        .Property(prod => prod.Id)
        //        .ValueGeneratedOnAdd();

        //    p_modelBuilder.Entity<StoreFront>()
        //        .Property(store => store.Id)
        //        .ValueGeneratedOnAdd();

        //    p_modelBuilder.Entity<InventoryItem>()
        //        .Property(item => item.Id)
        //        .ValueGeneratedOnAdd();

        //    p_modelBuilder.Entity<Order>()
        //        .HasMany<LineItem>(o => (IEnumerable<LineItem>)o.LineItems);

        //    p_modelBuilder.Entity<LineItem>()
        //        .HasRequired<Order>(l => l.Order)
        //        .WithMany(o => o.LineItems)
        //        .HasForeignKey<int>(l => l.OrderId);
        //}
    }
}