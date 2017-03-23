using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class AjaxController : Controller
    {

        List<String> books = new List<String> { "C# Comp. Ref", "Asp.Net MVC Unleashed", "AngularJS" };

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string title)
        {
            return View();
        }



        public String Now()
        {
            return DateTime.Now.ToString();
        }

        public String Title(int id)
        {
            if (id <= books.Count)
                return books[id - 1];
            else
                return "";
        }
    }
}