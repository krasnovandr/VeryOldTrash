using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskShop.Repositories;

namespace TaskShop.Repositories
{

    //public interface IBatteriesRepository
    //{
    //    void AddBattery(Battery battery);
    //    List<Battery> GetBatteries();
    //    Battery GetBattery(int id);
    //}


    //public class BatteriesRepository : IBatteriesRepository
    //{

    //    public void AddBattery(Battery battery)
    //    {
    //        using (var db = new ShopContext())
    //        {
    //            db.Batteries.Add(battery);
    //            db.SaveChanges();
    //        }
    //    }

    //    public List<Battery> GetBatteries()
    //    {
    //        using (var db = new ShopContext())
    //        {
    //            var batteries = (from entity in db.Batteries
    //                             select entity).ToList();
    //            return batteries;
    //        }
    //    }

    //    public Battery GetBattery(int id)
    //    {
    //        using (var db = new ShopContext())
    //        {
    //            var battery = (from entity in db.Batteries
    //                           where entity.Id == id
    //                           select entity).FirstOrDefault();
    //            return battery;
    //        }
    //    }
    //}
}