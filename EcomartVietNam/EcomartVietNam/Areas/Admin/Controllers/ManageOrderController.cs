using EcomartVietNam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomartVietNam.Areas.Admin.Controllers
{
    public class ManageOrderController : Controller
    {
        EcomartStoreDB db = new EcomartStoreDB();

        // GET: Admin/ManageOrder
        public ActionResult Index()
        {

            var order = db.Orders.Join(db.Users, o => o.user_id, u => u.user_id, (o, u) => new
            {
                order = o,
                user = u
            }).Select(o => new
            {
                order_id = o.order.order_id,
                user_id = o.user.full_name,
                created_at = o.order.created_at
            }).ToList();
            //var result = (from od in db.Orders
            //             join us in db.Users on od.user_id equals us.user_id
            //             join odt in db.Order_detail on od.order_id equals odt.order_id
            //             group od by new { od.order_id, us.full_name, odt.quantity, odt.price } into g
            //             select new
            //             {
            //                 oder_id = g.Key.order_id,
            //                 user_id = g.Key.full_name,

            //             }).OrderByDescending(a=>a.oder_id) ;
            List<string> status = new List<string>
            {
                "Đã giao",  "Đang giao",  "Đã hủy"
            };
            ViewBag.Status = status;
            return View(order);
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