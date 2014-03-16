using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Repositories;
using TaskShop.Repositories;
using TaskShop.Services;
using Shared;

namespace TaskShop.Controllers
{
    public class MonitorsController : Controller
    {
        //
        // GET: /Monitors/

       private readonly IMonitorsService _service;

        ////
        //// GET: /Batteries/

       public MonitorsController(IMonitorsService service)
        {
            this._service = service;
        }
       public JsonResult GetAll()
       {
           var monitors = _service.GetMonitors();
           return Json(monitors, JsonRequestBehavior.AllowGet);
       }

       [HttpPost]
       public JsonResult Add(Monitor monitor)
       {
           //if (ModelState.IsValid)
           //{
           _service.AddMonitor(monitor);
           return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
           //}
           //var allErrors = ModelState.Values.SelectMany(v => v.Errors);

           //return Json(allErrors);
       }

       [HttpGet]
       public JsonResult GetById(int id)
       {
           var monitor = _service.GetMonitor(id);

           return Json(monitor, JsonRequestBehavior.AllowGet);
       }

    }
}
