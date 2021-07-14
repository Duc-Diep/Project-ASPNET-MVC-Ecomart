using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace EcomartVietNam.Controllers
{
    public class CategoryController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Category
        public ActionResult Detail(int id, int? page)
        {
            ViewBag.Account = Session["client_id"] == null ? null : Session["client_name"].ToString();
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            ViewBag.Category = category;

            var products = db.Products.Where(p => p.category_id == id).OrderByDescending(p => p.product_id);
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, 12));

            if (category == null)
            {
                return HttpNotFound();
            }
        }
    }
}