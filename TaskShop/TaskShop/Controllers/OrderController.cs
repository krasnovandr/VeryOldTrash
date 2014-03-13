using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private readonly IOrdersRepository _repository;

        public OrderController(IOrdersRepository repository)
        {
            this._repository = repository;
        }
        [HttpPost]
        public JsonResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                var cartList = (List<Cart>)Session["CartList"];
                _repository.AddOrder(order, cartList);
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(allErrors);
        }

    }
}
