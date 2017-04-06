using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class CatalogContext : DbContext 
    {
        public CatalogContext() : base("name=localdbconnection")
        {

        }

        public DbSet<Title> Titles { get; set; }
    }
}