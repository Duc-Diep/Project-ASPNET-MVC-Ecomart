using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageProductController : ProtectAdminController
    {
        EcomartStoreDB db = new EcomartStoreDB();

        // GET: Admin/ManageProduct
        public ActionResult Index(string searchString)
        {
            var products = db.Products.Select(p=>p);
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.product_name.Contains(searchString));
            }
            
            return View(products.ToList());
        }
        // GET: Admin/ManageProduct/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.product_image = "";
                    var f = Request.Files["product_image"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/product/images/" + FileName);
                        f.SaveAs(UploadPath);
                        product.product_image = FileName;
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", product.category_id);
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                return View(product);
            }
        }

        // GET: Admin/ManageProduct/Update
        public ActionResult Update(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name",product.category_id);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.product_image = "";
                    var f = Request.Files["product_image"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/wwwroot/product/images/" + FileName);
                        f.SaveAs(UploadPath);
                        product.product_image = FileName;
                    }
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", product.category_id);
                return View(product);
            }


        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}