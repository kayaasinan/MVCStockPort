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
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
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
        public ActionResult GetCustomerById(int id)
        {
            var cstmr=db.TblCustomer.Find(id);
            return View("GetCustomerById",cstmr);
        }
        public ActionResult Update(TblCustomer p1)
        {
            var ktg = db.TblCustomer.Find(p1.CustomerId);
            ktg.CustomerName = p1.CustomerName;
            ktg.CustomerSurname = p1.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}