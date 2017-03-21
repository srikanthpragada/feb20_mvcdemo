using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Wish(String id)
        {
            ViewBag.Message = "Name :" + id;
            return View();
        }

        public ActionResult Course()
        {
            // Send model (Course object) to view 
            return View(new Course());
        }

        public ActionResult List()
        {
            List<Course> courses = new List<Course>();
            courses.Add(new Models.Course { Name = "Java SE", Duration = 40 });
            courses.Add(new Models.Course { Name = "Angular", Duration = 10 });
            courses.Add(new Models.Course { Name = "Asp.Net MVC", Duration = 15 });

            return View(courses);
        }
    }
}