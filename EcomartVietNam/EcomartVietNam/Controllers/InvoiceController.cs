using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Controllers
{
    public class InvoiceController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();
        // GET: Invoice
        public ActionResult Index()
        {
            ViewBag.Account = Session["client_id"] == null ? null : Session["client_name"].ToString();
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

    }
}