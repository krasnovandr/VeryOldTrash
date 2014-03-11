using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class MonitorsController : Controller
    {
        //
        // GET: /Monitors/

        private readonly IMonitorsRepository _repository;

        public MonitorsController(IMonitorsRepository repository)
        {
            this._repository = repository;
        }

        public JsonResult Get()
        {
            var monitors = _repository.GetMonitors();
            return Json(monitors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                _repository.AddMonitor(monitor);
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors);
        }

    }
}
