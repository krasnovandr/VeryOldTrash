using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        private readonly ISearchRepository _repository;

        public SearchController(ISearchRepository repository)
        {
            this._repository = repository;
        }

        public JsonResult GetAll(string modelName)
        {
            var items = _repository.GetAll(modelName);
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}
