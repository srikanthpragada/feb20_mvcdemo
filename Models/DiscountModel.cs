using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class DiscountModel
    {
        [Range(1000,100000, ErrorMessage = "Amount must be 1000 to 100000")]
        public double Amount { get; set; }

        [Range(5, 50, ErrorMessage = "Discount rate must be 5 to 50")]
        public double Rate { get; set; }

        public double Discount { get; set; }

    }
}