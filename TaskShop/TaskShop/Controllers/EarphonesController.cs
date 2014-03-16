using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared;
using TaskShop.Repositories;
using TaskShop.Repositories;
using TaskShop.Services;

namespace TaskShop.Controllers
{
    public class EarphonesController : Controller
    {
        private readonly IEarponesService _service;


        public EarphonesController(IEarponesService service)
        {
            this._service = service;
        }
        public JsonResult GetAll()
        {
            var earphones = _service.GetEarphones();
            return Json(earphones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Earphone earphone)
        {
            _service.AddEarphone(earphone);
            return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var earphone = _service.GetEarphone(id);
            return Json(earphone, JsonRequestBehavior.AllowGet);
        }

    }
}
