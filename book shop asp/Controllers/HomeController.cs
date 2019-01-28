using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book_shop_asp.Controllers
{
    public class HomeController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        public ActionResult Index()
        {
            //return new HttpNotFoundResult();
            //new HttpStatusCodeResult(404);
            //new HttpUnauthorizedResult(); // er 401 - no access
            HttpContext.Response.Cookies["id"].Value = "1337"; // set cookie
            Session["name"] = "Daniel"; // set session
            ViewBag.Books = db.Books.OrderBy(b => b.Id).Skip(1).Take(3);

            return View();
        }

        public ActionResult AddMessage(string Name, string Msg)
        {
            string uip = HttpContext.Request.UserHostAddress;
            string uinfo = HttpContext.Request.UserAgent;

            Messages msg = new Messages();
            msg.Name = Name;
            msg.Msg = Msg;
            msg.U_ip = uip;
            msg.U_info = uinfo.Substring(0, 27);

            db.Messages.Add(msg);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Response.Write("Object: " + validationError.Entry.Entity.ToString());
                    Response.Write("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Response.Write(err.ErrorMessage + "");
                    }
                }
            }

            return RedirectPermanent("/Home/Index");
        }

        public ActionResult BuyBook(int id)
        {
            ViewBag.BuyedBook = db.Books.Where(b => b.Id == id);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            // ViewData["title"] = "Document";
            HttpContext.Response.Write(HttpContext.Response.Cookies["id"].Value); // get cookie
            //db.Messages.Add(new Messages { Name = "sdf", Msg = "zxc", U_info = "qwe", U_ip = "uio" });
            //db.SaveChanges();
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
            ViewBag.Books = db.Books.ToList();

            SelectList authors = new SelectList(db.Authors, "FirstName", "FirstName");
            ViewBag.Authors = authors;

            return View();
        }
    }
}