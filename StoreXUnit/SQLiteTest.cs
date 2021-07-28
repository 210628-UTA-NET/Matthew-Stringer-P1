// Adapted from https://www.c-sharpcorner.com/article/unit-testing-with-inmemory-provider-and-sqlite-in-memory-database-in-efcore/
using StoreClasslib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace StoreXUnit
{
    public class SQLiteTest
    {
        [Fact]
        public void Task_Add_Without_Relation()
        {
            //Arrange    
            ConnectionFactory factory = new();

            //Get the instance of BlogDBContext  
            StoreDBContext context = factory.CreateContextForSQLite();

            LineItem item = new()
            {
                Quantity = 2
            };

            //Act    
            var data = context.LineItems.Add(item);

            //Assert   
            Assert.Throws<DbUpdateException>(() => context.SaveChanges());
            Assert.Empty(context.LineItems.ToList());
        }

    }
}