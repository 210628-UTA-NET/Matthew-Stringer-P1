// Adapted from https://www.c-sharpcorner.com/article/unit-testing-with-inmemory-provider-and-sqlite-in-memory-database-in-efcore/
using StoreClasslib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace StoreXUnit
{
    public class ConnectionFactory : IDisposable
    {

        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public StoreDBContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<StoreDBContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new StoreDBContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        public StoreDBContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite(connection).Options;

            var context = new StoreDBContext(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}