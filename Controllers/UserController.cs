using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password)
        {
            if (password == "test")
            {
                FormsAuthentication.SetAuthCookie("admin", false);
                return RedirectToAction("Index", "Hello");
            }
            else
                ViewBag.Message = "Invalid Login!";
            return View();

        }
    }
}