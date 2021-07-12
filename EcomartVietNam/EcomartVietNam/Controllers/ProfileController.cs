using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Controllers
{
    public class ProfileController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Profile
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return Redirect("/Profile/Login");
            }
            return View();
        }

        public ActionResult ChangePass()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            return Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string email = frm["email"];
                string password = frm["password"];

                string currentPass = EncodePassword(password);
                var data = db.Users.Where(s => s.email.Equals(email) && s.password.Equals(currentPass)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().full_name;
                    Session["user"] = data.FirstOrDefault().user_id;
                    return Redirect("/");
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
        public ActionResult Register()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            return Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection frm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string full_name = frm["full_name"];
                    string email = frm["email"];
                    string password = frm["password"];
                    string confirm_password = frm["confirm_password"];

                    if (!password.Equals(confirm_password))
                    {
                        ViewBag.Error = "Mật khẩu không khớp.";
                        return View();
                    }

                    var user = db.Users.Where(us => us.email == email).SingleOrDefault();

                    if (user != null)
                    {
                        ViewBag.Error = "Vui lòng nhập địa chỉ email khác.";
                        return View();
                    }

                    User u = new User();
                    u.full_name = full_name;
                    u.email = email;
                    u.password = EncodePassword(password);
                    u.role = 0;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(u);
                    db.SaveChanges();
                }
                return Redirect("/Profile/Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi dữ liệu " + ex;
                return View();
            }
        }

        public static string EncodePassword(string originalPassword)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
    }
}