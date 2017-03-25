using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class AjaxController : Controller
    {
        List<String> books = new List<String>
          { "C# Comp. Ref",
            "Asp.Net MVC Unleashed",
            "AngularJS",
            "C# Cook Book",
            "Asp.Net Unleashed"};
            
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Search(string title)
        {
            List<String> selbooks = new List<String>();

            foreach (string book in books)
                if (book.Contains(title))
                    selbooks.Add(book);

            return PartialView("books", selbooks);
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