using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStockEntities db=new MvcDbStockEntities();
        public ActionResult Index()
        {
            var values=db.TblProduct.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values=(from i in db.TblCategory.ToList()
                                         select new SelectListItem
                                         {
                                             Text=i.CategoryName,
                                             Value=i.CategoryId.ToString(),
                                         }).ToList();
            ViewBag.vls=values;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(TblProduct p1)
        {
            var ctg=db.TblCategory.Where(i=>i.CategoryId==p1.TblCategory.CategoryId).FirstOrDefault();
            p1.TblCategory=ctg;
            db.TblProduct.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var values = db.TblProduct.Find(id);
            db.TblProduct.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}