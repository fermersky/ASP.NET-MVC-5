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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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
            //Request.Params["a"] GET
           // int a = Request.Form["d"]; POST
            return View();
        }

        public void CommitAdding(Books book)
        {
            book.IsDeleted = false;
            book.PublishDate = DateTime.Now;
            db.Books.Add(book);
            db.SaveChanges();
        }
    }
}