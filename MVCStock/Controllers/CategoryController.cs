using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(TblCategory p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TblCategory.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var values = db.TblCategory.Find(id);
            db.TblCategory.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategoryById(int id)
        {
            var ktgr=db.TblCategory.Find(id);
            return View("GetCategoryById",ktgr);
        }
        public ActionResult Update(TblCategory p1)
        {
            var ktg=db.TblCategory.Find(p1.CategoryId);
            ktg.CategoryName = p1.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}