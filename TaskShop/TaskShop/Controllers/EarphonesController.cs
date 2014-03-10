using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class EarphonesController : Controller
    {
        //
        private readonly IEarphonesRepository _repository;

        public EarphonesController(IEarphonesRepository repository)
        {
            this._repository = repository;
        }

        public JsonResult GetResult()
        {
            var earphones = _repository.GetEarphones();
            return Json(earphones, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEarphone(Earphone earphone)
        {
            if (ModelState.IsValid)
            {
                _repository.AddEarphone(earphone);
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors);
        }

    }
}
