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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string email = frm["email"];
                string password = frm["password"];
                var data = db.Users.Where(s => s.email.Equals(email) && s.password.Equals(password)).ToList();
                if (data.Count() > 0 && data.FirstOrDefault().role == 1)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().full_name;
                    Session["user"] = data.FirstOrDefault().user_id;
                    return Redirect("/Admin/Manage");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return View();
                }
            }
            ViewBag.error = "Đăng nhập thất bại";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}