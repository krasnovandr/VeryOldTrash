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

        public JsonResult AddBook(Book book)
        {

            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors); ;
        }
        public JsonResult GetBooks()
        {
            //var a = Json(repository.GetBooks(),JsonRequestBehavior.AllowGet));
            List<Book> books = repository.GetBooks();
            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}
