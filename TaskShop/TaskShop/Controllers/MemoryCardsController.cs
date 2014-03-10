using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class MemoryCardsController : Controller
    {
        //
        // GET: /MemoryCards/

        private readonly IMemoryCardsRepository _repository;

        public MemoryCardsController(IMemoryCardsRepository repository)
        {
            this._repository = repository;
        }

        public JsonResult GetResult()
        {
            var memoryCards = _repository.GetMemoryCards();
            return Json(memoryCards, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMemoryCard(MemoryCard memoryCard)
        {
            if (ModelState.IsValid)
            {
                _repository.AddMemoryCard(memoryCard);
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors);
        }

    }
}
