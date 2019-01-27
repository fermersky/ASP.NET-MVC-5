using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book_shop_asp.Controllers
{
    public class AdminController : Controller
    {
        private BookShopEntities db = new BookShopEntities();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Books = db.Books;
            return View();
        }
    }
}