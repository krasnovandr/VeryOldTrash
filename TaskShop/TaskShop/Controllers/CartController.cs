using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public JsonResult AddBattery(Battery battery)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBattery(battery);
                return Json(new { item = "Added" });
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors);
        }

        [HttpPost]
        public JsonResult AddMonitor(Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                _repository.AddMonitor(monitor);
                return Json(new { item = "Added" });
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors);
        }

        public JsonResult Get()
        {
            var carts = _repository.GetCarts();
            return Json(carts, JsonRequestBehavior.AllowGet);
        }

        public bool Delete(int id)
        {
            var result = _repository.Delete(id);
            return result;
        }
    }
}
