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
using TaskShop.Shared;

namespace TaskShop.Controllers
{
    public class BatteriesController : Controller
    {
        private readonly IBatteriesService _service;

        ////
        //// GET: /Batteries/

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
            //if (ModelState.IsValid)
            //{
                _service.AddBattery(battery);
                return Json(new { item = "Added" }, JsonRequestBehavior.AllowGet);
            //}
            //var allErrors = ModelState.Values.SelectMany(v => v.Errors);

            //return Json(allErrors);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var battery = _service.GetBattery(id);

            return Json(battery, JsonRequestBehavior.AllowGet);
        }

    }
}

//
// GET: /Batteries/Details/5

//public ActionResult Details(int id = 0)
//{
//    Battery battery = db.Batteries.Find(id);
//    if (battery == null)
//    {
//        return HttpNotFound();
//    }
//    return View(battery);
//}

////
//// GET: /Batteries/Create

//public ActionResult Create()
//{
//    return View();
//}

////
//// POST: /Batteries/Create

//[HttpPost]
//public ActionResult Create(Battery battery)
//{
//    if (ModelState.IsValid)
//    {
//        db.Batteries.Add(battery);
//        db.SaveChanges();
//        return RedirectToAction("Index");
//    }

//    return View(battery);
//}

////
//// GET: /Batteries/Edit/5

//public ActionResult Edit(int id = 0)
//{
//    Battery battery = db.Batteries.Find(id);
//    if (battery == null)
//    {
//        return HttpNotFound();
//    }
//    return View(battery);
//}

////
//// POST: /Batteries/Edit/5

//[HttpPost]
//public ActionResult Edit(Battery battery)
//{
//    if (ModelState.IsValid)
//    {
//        db.Entry(battery).State = EntityState.Modified;
//        db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    return View(battery);
//}

////
//// GET: /Batteries/Delete/5

//public ActionResult Delete(int id = 0)
//{
//    Battery battery = db.Batteries.Find(id);
//    if (battery == null)
//    {
//        return HttpNotFound();
//    }
//    return View(battery);
//}

////
//// POST: /Batteries/Delete/5

//[HttpPost, ActionName("Delete")]
//public ActionResult DeleteConfirmed(int id)
//{
//    Battery battery = db.Batteries.Find(id);
//    db.Batteries.Remove(battery);
//    db.SaveChanges();
//    return RedirectToAction("Index");
//}

//protected override void Dispose(bool disposing)
//{
//    db.Dispose();
//    base.Dispose(disposing);
//}