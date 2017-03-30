using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    [Table (Name = "products")]
    public class Product
    {
        [Column (Name = "prodid", IsPrimaryKey =true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "prodname")]
        public String Name { get; set; }

        [Column]
        public int Qoh { get; set; }
        [Column]
        public decimal Price { get; set; }
    }
}