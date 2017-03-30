using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            InventoryDataContext dc = new InventoryDataContext();
            return View(dc.Sales);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // create collection of SelectListItem
            InventoryDataContext dc = new InventoryDataContext();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Product p in dc.Products )
            {
                items.Add(new SelectListItem { Text = p.Name, Value = p.Id.ToString() });
            }
            ViewBag.Products = items; 

            Sale s = new Sale();
            s.TransDate = DateTime.Today.ToString("dd-MM-yyyy");
            return View(s);
        }

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            //  add Sale to Sales Table 
            return View(sale);
        }

    }
}