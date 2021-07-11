using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Admin/Manage
        public ActionResult Index()
        {
            return View();
        }

    }
}