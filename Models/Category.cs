using System;
using System.Data.Linq.Mapping;

namespace MvcDemo.Models
{
    [Table (Name ="categories")]
    public class Category
    {
        [Column ( Name = "catcode", IsPrimaryKey = true)]
        public String Code { get; set; }

        [Column (Name = "catdesc")]
        public String Description { get; set; }
    }
}