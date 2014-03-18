using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using Shared;


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
            Session["pageNumber"] = 0;
   
            return View();
        }

        public JsonResult GetNext()
        {
            var pageNumber = (int)Session["pageNumber"];
            var list = _service.GetAll();

            pageNumber += Constants.ItemsAtPage;

            if ((list.Count - pageNumber) < Constants.ItemsAtPage && (list.Count - pageNumber) > 0)
            {
                return Json(_service.GetAll().GetRange(pageNumber, list.Count - pageNumber),
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["pageNumber"] = pageNumber;
                return Json(_service.GetAll().GetRange(pageNumber, Constants.ItemsAtPage), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPrevious()
        {
            var pageNumber = (int)Session["pageNumber"];

            pageNumber -= Constants.ItemsAtPage;
            if (pageNumber < 0) return Json(_service.GetAll().GetRange(0, Constants.ItemsAtPage), JsonRequestBehavior.AllowGet);
            Session["pageNumber"] = pageNumber;
            return Json(_service.GetAll().GetRange(pageNumber, Constants.ItemsAtPage), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var list = _service.GetAll().GetRange(0, Constants.ItemsAtPage);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
