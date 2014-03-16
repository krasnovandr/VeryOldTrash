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
    public class MemoryCardsController : Controller
    {
      private readonly IMemoryCardsService _service;


      public MemoryCardsController(IMemoryCardsService service)
        {
            this._service = service;
        }
        public JsonResult GetAll()
        {
            var memoryCards = _service.GetMemoryCards();
            return Json(memoryCards, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(MemoryCard memoryCard)
        {
            _service.AddMemoryCard(memoryCard);
            return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var memoryCard = _service.GetMemoryCard(id);
            return Json(memoryCard, JsonRequestBehavior.AllowGet);
        }

    }
}
