using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            ViewBag.Account = Session["user"] == null ? null : Session["FullName"].ToString();
            return View();
        }

    }
}