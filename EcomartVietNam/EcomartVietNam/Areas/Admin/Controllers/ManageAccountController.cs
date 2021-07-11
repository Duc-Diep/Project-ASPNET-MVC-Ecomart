using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageAccountController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Admin/Account
        public ActionResult Index()
        {
            var account = db.Users.ToList();
            return View(account);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
    }
}