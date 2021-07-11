using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageCategoryController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Admin/ManageCategory
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
        // GET: Admin/ManageCategory/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Admin/ManageCategory/Update
        public ActionResult Update()
        {
            return View();
        }
        
        public ActionResult Delete()
        {
            return View();
        }
    }
}