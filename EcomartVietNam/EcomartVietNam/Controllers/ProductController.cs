using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Controllers
{
    public class ProductController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Product
        public ActionResult Detail(int id)
        {
            ViewBag.Account = Session["client_id"] == null ? null : Session["client_name"].ToString();
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}