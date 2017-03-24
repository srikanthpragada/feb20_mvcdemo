using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MvcDemo.Models
{
    public class Database
    {
        public static String LocalDbConnection
        {
            get
            {
                return WebConfigurationManager
                           .ConnectionStrings["localdbconnection"]
                           .ConnectionString;
            }
        }
    }
}