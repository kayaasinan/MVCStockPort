using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcDbStockEntities db = new MvcDbStockEntities();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Products = db.TblProduct.Select(x => new SelectListItem
            {
                Text = x.ProductName,
                Value = x.ProductId.ToString()
            }).ToList();

            ViewBag.Customers = db.TblCustomer.Select(x => new SelectListItem
            {
                Text = x.CustomerName + " " + x.CustomerSurname,
                Value = x.CustomerId.ToString()
            }).ToList();

            return View();
        }
       
        [HttpPost]
        public ActionResult NewSale(TblProcess p1)
        {
            db.TblProcess.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}