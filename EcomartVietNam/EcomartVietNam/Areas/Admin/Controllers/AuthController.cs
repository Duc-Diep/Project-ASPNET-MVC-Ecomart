using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();

        // GET: Admin/Auth
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/Auth/Login
        public ActionResult Login()
        {
            return View();
        }
    }
}