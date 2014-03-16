using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;
using TaskShop.Repositories;
using Shared;

namespace TaskShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }


        public JsonResult Get()
        {
            var cartList = (List<Cart>)Session["CartList"];
            return Json(cartList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBattery(Battery battery)
        {
            if (ModelState.IsValid)
            {
                var sessionCart = (List<Cart>)Session["CartList"];

                if (sessionCart == null)
                {
                    var tmp = new List<Cart>();
                    _repository.AddBattery(battery, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _repository.AddBattery(battery, sessionCart);
                    Session["CartList"] = sessionCart;
                }
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
                var sessionCart = (List<Cart>)Session["CartList"];

                if (sessionCart == null)
                {
                    var tmp = new List<Cart>();
                    _repository.AddMonitor(monitor, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _repository.AddMonitor(monitor, sessionCart);
                    Session["CartList"] = sessionCart;
                }
                return Json(new { item = "Added" });
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return Json(allErrors);
        }

        [HttpPost]
        public JsonResult AddEarphone(Earphone earphone)
        {
            if (ModelState.IsValid)
            {
                var sessionCart = (List<Cart>)Session["CartList"];

                if (sessionCart == null)
                {
                    var tmp = new List<Cart>();
                    _repository.AddEarphone(earphone, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _repository.AddEarphone(earphone, sessionCart);
                    Session["CartList"] = sessionCart;
                }
                return Json(new { item = "Added" });
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return Json(allErrors);
        }
      
        [HttpPost]
        public JsonResult AddMemoryCard(MemoryCard memoryCard)
        {
            if (ModelState.IsValid)
            {
                var sessionCart = (List<Cart>)Session["CartList"];

                if (sessionCart == null)
                {
                    var tmp = new List<Cart>();
                    _repository.AddMemoryCard(memoryCard, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _repository.AddMemoryCard(memoryCard, sessionCart);
                    Session["CartList"] = sessionCart;
                }
                return Json(new { item = "Added" });
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            return Json(allErrors);
        }

        public void Delete(Cart cart)
        {
            var cartList = (List<Cart>)Session["CartList"];
            _repository.Delete(cart, cartList);
        }
    }
}
