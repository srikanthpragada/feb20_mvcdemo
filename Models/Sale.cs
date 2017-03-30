using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    [Table (Name = "sales")]
    public class Sale
    {

        [Column(Name = "invno", IsDbGenerated =true, IsPrimaryKey = true)]
        public int InvoiceNo { get; set; }

        [Column(Name = "prodid")]
        public int ProductId { get; set; }

        [Column(Name = "TransDate")]
        public String TransDate { get; set; }

        [Column]
        public int Qty { get; set; }

        [Column]
        public decimal Amount { get; set; }
    }
}