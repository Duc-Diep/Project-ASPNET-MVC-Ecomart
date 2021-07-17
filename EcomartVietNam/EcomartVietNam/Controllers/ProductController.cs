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
    public class ProductController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Product
        public ActionResult Detail(int id)
        {
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
        public ActionResult Search(string keyword, string order, decimal? fromPrice, decimal? toPrice,string category, int page=1)
        {
            if(keyword == null)
            {
                keyword = "";
            } 
            var products = db.Products.Where(p => p.product_name.Contains(keyword)).OrderByDescending(p => p.product_id);

            if (order != null)
                switch (order)
                {
                    case "desc":
                        products = products.OrderByDescending(p => p.product_price);
                        ViewBag.order = "desc";
                        break;
                    case "asc":
                        products = products.OrderBy(p => p.product_price);
                        ViewBag.order = "asc";
                        break;
                    default:
                        ViewBag.order = "default";
                        break;
                }

            if (fromPrice != null)
            {
                ViewBag.from = fromPrice;
                products = (IOrderedQueryable<Product>)products.Where(p => p.product_price >= fromPrice);
            }

            if (toPrice != null)
            {
                ViewBag.to = toPrice;
                products = (IOrderedQueryable<Product>)products.Where(p => p.product_price <= toPrice);
            }

            if(category != null)
            {
                string[] ids = category.Split(',');
                ViewBag.category = category;
                products = (IOrderedQueryable<Product>)products.Where(p => ids.Contains(p.category_id.ToString()));
            }

            ViewBag.keyword = keyword;
            ViewBag.Categories = db.Categories.OrderBy(c => c.category_id).ToList();
            return View(products.ToPagedList(page, 12));
        }
    }
}