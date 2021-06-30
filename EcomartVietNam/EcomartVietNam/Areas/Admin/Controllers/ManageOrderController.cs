using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageOrderController : Controller
    {
        // GET: Admin/ManageOrder
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/ManageOrder/id
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Details(int ID)
        {
            return View();
        }
    }
}