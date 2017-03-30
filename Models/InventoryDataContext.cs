using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class InventoryDataContext : DataContext
    {
        public InventoryDataContext() : base(Database.LocalDbConnection)
        { }

        public Table<Category> Categories
        {
            get
            {
                return GetTable<Category>();
            }
        }

        public Table<Product> Products
        {
            get
            {
                return GetTable<Product>();
            }
        }

        public Table<Sale> Sales
        {
            get
            {
                return GetTable<Sale>();
            }
        }
    }
}