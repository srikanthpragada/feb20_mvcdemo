using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    [Table("Titles")]
    public class Title
    {
        [Key]
        public int TitleId { get; set; }

        [Column("Title")]
        public string Name { get; set; }

        [Column]
        public string Author { get; set; }

        [Column]
        public int Price { get; set; }

    }
}