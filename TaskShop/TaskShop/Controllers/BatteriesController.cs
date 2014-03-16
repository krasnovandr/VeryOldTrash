using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Repositories;
using TaskShop.Repositories;
using TaskShop.Services;
using Shared;

namespace TaskShop.Controllers
{
    public class BatteriesController : Controller
    {
        private readonly IBatteriesService _service;

   
        public BatteriesController(IBatteriesService service)
        {
            this._service = service;
        }
        public JsonResult GetAll()
        {
            var batteries = _service.GetBatteries();
            return Json(batteries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Battery battery)
        {
            _service.AddBattery(battery);
            return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var battery = _service.GetBattery(id);
            return Json(battery, JsonRequestBehavior.AllowGet);
        }

    }
}

