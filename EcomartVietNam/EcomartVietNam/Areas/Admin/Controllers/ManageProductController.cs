using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageProductController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();

        // GET: Admin/ManageProduct
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return Redirect("/Admin/Auth/Login");
            }
            return View();
        }
        // GET: Admin/ManageProduct/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Admin/ManageProduct/Update
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