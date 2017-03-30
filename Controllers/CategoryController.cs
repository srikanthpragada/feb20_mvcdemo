using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            InventoryDataContext ctx = new InventoryDataContext();
            return View(ctx.Categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Category cat = new Category();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            try {
                ctx.Categories.InsertOnSubmit(cat);
                ctx.SubmitChanges();
                ViewBag.Message = "Category Added Successfully!";
                cat = new Category();
            }
            catch(Exception  ex)
            {
                ViewBag.Message = "Sorry! Could not add category!";
            }
            return View(cat);
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            var cat = (from c in ctx.Categories
                       where c.Code == id
                       select c).SingleOrDefault();

            if (cat != null)
                return View(cat);
            else
                return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Edit(Category newcat)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            try
            {
                var cat = (from c in ctx.Categories
                           where c.Code == newcat.Code 
                           select c).SingleOrDefault();

                if (cat != null)
                {
                    cat.Description = newcat.Description;
                    ctx.SubmitChanges();
                }
                else
                    TempData["message"] = "Sorry! Could not find category!";
            }
            catch (Exception ex)
            {
                TempData["message"] = "Sorry! Could not update category!";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(string id)
        {
            InventoryDataContext ctx = new InventoryDataContext();
            var cat = (from c in ctx.Categories
                       where c.Code == id
                       select c).SingleOrDefault();

            if (cat != null)
            {
                try {
                    ctx.Categories.DeleteOnSubmit(cat);
                    ctx.SubmitChanges();
                    TempData["message"] = "Deleted Category [" + id + "]";
                }
                catch(Exception ex)
                {
                    TempData["message"] = "Error : " + ex.Message;
                }
            }
            else
            {
                TempData["message"] = "Category [" + id + "] Not Found!";
            }
            
            return RedirectToAction("Index");
        }
    }
}