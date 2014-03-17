using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using ServiceLayer;


namespace TaskShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _service;

        public CartController(ICartService repository)
        {
            _service = repository;
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
                    _service.AddBattery(battery, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _service.AddBattery(battery, sessionCart);
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
                    _service.AddMonitor(monitor, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _service.AddMonitor(monitor, sessionCart);
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
                    _service.AddEarphone(earphone, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _service.AddEarphone(earphone, sessionCart);
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
                    _service.AddMemoryCard(memoryCard, tmp);
                    Session["CartList"] = tmp;
                }
                else
                {
                    _service.AddMemoryCard(memoryCard, sessionCart);
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
            _service.Delete(cart, cartList);
        }
    }
}
