using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStockEntities db=new MvcDbStockEntities();
        public ActionResult Index()
        {
            var values=db.TblCustomer.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(TblCustomer p1)
        {
            db.TblCustomer.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var values= db.TblCustomer.Find(id);
            db.TblCustomer.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}