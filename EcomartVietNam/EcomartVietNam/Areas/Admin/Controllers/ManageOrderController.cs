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
        public ActionResult Index(int ID)
        {
            return View();
        }
    }
}