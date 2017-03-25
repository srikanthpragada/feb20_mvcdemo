using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            var products = InventoryDAL.GetProducts();
            return View(products);
        }

        public ActionResult Delete(int id)
        {
            // var product = InventoryDAL.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = InventoryDAL.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            bool done = InventoryDAL.UpdateProduct(id, product);
            if (done)
                ViewBag.Message = "Updated Product Details Successfully!";
            else
                ViewBag.Message = "Sorry! Could not update details. Try again!";

            return View(product);
        }
    }
}