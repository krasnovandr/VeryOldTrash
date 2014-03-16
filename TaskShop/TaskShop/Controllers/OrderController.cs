using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrdersRepository _repository;

        public OrderController(IOrdersRepository repository)
        {
            this._repository = repository;
        }
       
        [HttpPost]
        public JsonResult Add(Order order)
        {
            if (ModelState.IsValid)
            {
                var cartList = (List<Cart>)Session["CartList"];
                _repository.AddOrder(order, cartList); 
                Session["CartList"] = null;
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            }
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
           

            return Json(allErrors);
        }

        public JsonResult GetAll()
        {
            var orders = _repository.GetOrders();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var order = _repository.GetOrder(id);
            return Json(order, JsonRequestBehavior.AllowGet);
        }
    }
}
