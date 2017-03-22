using MvcDemo.Models;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class DiscountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            DiscountModel model = new DiscountModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DiscountModel model)
        {
            if (ModelState.IsValid)
                model.Discount = model.Amount * model.Rate / 100;
            else
                model.Discount = 0; 

            return View(model);
        }
    }
}