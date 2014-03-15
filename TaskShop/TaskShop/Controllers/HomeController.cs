using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
     

        public ActionResult Index()
        {
            //var monitor = new Commodity();
            //var battery = new Commodity();
            //using (var db = new ShopContext())
            //{
                

        

            //monitor.Model = "y570";
            //monitor.Price = 2120;
            //monitor.Producer = "Lenovo";
            //monitor.Category = "Monitors";

            //battery.Model = "sl10";
            //battery.Price = 20;
            //battery.Producer = "lenovo";
            //battery.Category = "Batteries";

       

            ////db.DbGoods.Add(battery);

            //var prop = new Property
            //{
            //    Name = "ScreenSize",
            //    ValueChar = "1920x1080",
            //};
            ////var prop2 = new Property
            ////{
            ////    Name = "Resolution",
            ////    ValueInt = 1,
            ////};

            ////Person john = new Person();
            ////john.FirstName = "John";
            ////john.LastName = "Paul";
            //for (int i = 0; i < 10; i++)
            //{
            //    db.DbGoods.Add(monitor);
            //    db.SaveChanges();
            //}

            ////prop2.Goods.Add(monitor);
            ////prop.Goods.Add(battery);
            //for (int i = 0; i < 10; i++)
            //{  prop.Goods.Add(monitor);
            //    db.DbProperties.Add(prop);
            //    db.SaveChanges();
            //}

            ////db.DbProperties.Add(prop2);
            //db.SaveChanges();
         
            return View();
            //}
        }

    }
}
