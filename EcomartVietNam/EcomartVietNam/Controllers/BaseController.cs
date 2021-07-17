using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Controllers
{
    public class BaseController : ProtectController
    {
        EcomartStoreDB db = new EcomartStoreDB();
        [NotAuthorize]
        public PartialViewResult _Header()
        {
            return PartialView(user);
        }
        [NotAuthorize]
        public PartialViewResult _MenuPC()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }
        [NotAuthorize]
        public PartialViewResult _MenuMobile()
        {
            ViewBag.User = user.full_name;
            var categories = db.Categories.ToList();
            return PartialView(categories);
        }
        [NotAuthorize]
        public PartialViewResult _BreadcrumbLevelOne(string id)
        {
            var category = db.Categories.Where(c => c.category_id.ToString() == id).SingleOrDefault();

            return PartialView(category);
        }
        [NotAuthorize]
        public PartialViewResult _BreadcrumbLevelTwo(string id)
        {
            var product = db.Products.Where(c => c.product_id.ToString() == id).SingleOrDefault();

            return PartialView(product);
        }
    }
}