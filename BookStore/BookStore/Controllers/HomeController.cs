using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Services;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private IBooksRepository repository;

        public HomeController()
        {
            repository = new BooksRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public string AddBook(Book book)
        {
            repository.AddBook(book);
            return "All is good";
        }

        public JsonResult GetBooks()
        {
            //var a = Json(repository.GetBooks(),JsonRequestBehavior.AllowGet));
            List<Book> books = repository.GetBooks();
            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}
