using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;


namespace TaskShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAll()
        {
            return Json(_service.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}
