using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class CacheController : Controller
    {
         
        [OutputCache ( Duration =  120 , VaryByParam = "*")]
        public ActionResult Index()
        {
            ViewBag.Message = DateTime.Now.ToString();
            return View();
        }

        // Data caching demo
        public ActionResult Now()
        {
            DateTime date;
            Object data = HttpContext.Cache.Get("now");
            if (data == null)
            {
                date = DateTime.Now;
                HttpContext.Cache.Insert("now", date, null,
                    DateTime.MaxValue,
                    TimeSpan.FromMinutes(2));
            }
            else
                date = (DateTime) data;

            ViewBag.Message = date.ToString(); 
            return View();
        }

        // Data caching demo
        public ActionResult Today()
        {
            DateTime date;
            Object data = HttpContext.Cache.Get("now");
            if (data == null)
            {
                date = DateTime.Now;
                HttpContext.Cache.Insert("now", date, null,
                    DateTime.MaxValue,
                    TimeSpan.FromMinutes(2));
            }
            else
                date = (DateTime)data;

            ViewBag.Message = date.ToString("dd-MM-yyyy");
            return View();
        }
    }
}