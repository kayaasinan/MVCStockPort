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
        public ActionResult GetProductById(int id)
        {
            var prdct=db.TblProduct.Find(id);
            List<SelectListItem> values = (from i in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString(),
                                           }).ToList();
            ViewBag.vls = values;
            return View("GetProductById",prdct);
        }
        public ActionResult Update(TblProduct p1)
        {
            var prdt=db.TblProduct.Find(p1.ProductId);
            prdt.ProductName = p1.ProductName;
            prdt.ProductBrand=p1.ProductBrand;
            //prdt.ProductCategory=p1.ProductCategory;
            var ctg = db.TblCategory.Where(i => i.CategoryId == p1.TblCategory.CategoryId).FirstOrDefault();
            prdt.ProductCategory = ctg.CategoryId;
            prdt.ProductPrice=p1.ProductPrice;
            prdt.ProductStock=p1.ProductStock;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}