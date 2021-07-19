using Microsoft.EntityFrameworkCore;
using StoreClasslib;
using System;

namespace StoreDL
{
    public class StoreContext : DbContext
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

        //protected override void OnConfiguring(DbContextOptionsBuilder p_options)
        //{
        //    p_options.UseNpgsql(@"Server=batyr.db.elephantsql.com;Database=moaualdq;User Id=moaualdq;Password=");
        //}

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            //It will auto generate the ID column for both tables

            p_modelBuilder.Entity<Customer>()
                .Property(cust =>  cust.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<LineItem>()
                .Property(item => item.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Order>()
                .Property(order => order.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Product>()
                .Property(prod => prod.Id)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<StoreFront>()
                .Property(store => store.Id)
                .ValueGeneratedOnAdd();
        }
    }
}