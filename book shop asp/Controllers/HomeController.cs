using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book_shop_asp.Controllers
{
    public class HomeController : Controller
    {
        private BookShopContext db = new BookShopContext();

        public ActionResult Index()
        {
            //return new HttpNotFoundResult();
            //new HttpStatusCodeResult(404);
            //new HttpUnauthorizedResult(); // er 401 - no access
            HttpContext.Response.Cookies["id"].Value = "1337"; // set cookie
            Session["name"] = "Daniel"; // set session
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            // ViewData["title"] = "Document";
            HttpContext.Response.Write(HttpContext.Response.Cookies["id"].Value); // get cookie
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Books()
        {
            ViewBag.Books = db.Books.Where(b => b.IsDeleted == false);
            return View();
        }

        public ActionResult AddBook()
        {
            ViewBag.Authors = db.Authors;
            ViewBag.Genres = db.Genres;
            return View();
        }

        public ActionResult CommitAdding(Books book)
        {
            book.IsDeleted = false;
            book.PublishDate = DateTime.Now;
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToRoute(new { contoller = "Home", action = "Books", });
            // return RedirectToAction("Method", "Home", new { name = "Daneil" }); // transmit get params
            // return RedirectPermanent("/Home/Books");
        }

        public ActionResult BookOnCard()
        {
            ViewBag.Books = db.Books.Where(b => b.IsDeleted == false);
            return View();
        }

        public FileResult Download()
        {
            string path = Server.MapPath("~/Files/hi.txt");
            string ext = "application/octet-stream"; // universal file extention
            string name = "hi.txt";
            return File(path, ext, name); // sending a file
        }

        public ViewResult UserInfo()
        {
            HttpContext.Response.Write("idi naher");

            ViewBag.browser = HttpContext.Request.Browser.Browser;
            ViewBag.user_agent = HttpContext.Request.UserAgent; // os
            ViewBag.url = HttpContext.Request.Url;
            ViewBag.ip = HttpContext.Request.UserHostAddress;
            
            return View();
        }
    }
}