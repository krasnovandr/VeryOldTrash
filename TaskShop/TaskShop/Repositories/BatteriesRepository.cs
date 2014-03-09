using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskShop.Models;

namespace TaskShop.Repositories
{
  
    public interface IBatteriesRepository
    {
        void AddBattery(Battery battery);
        List<Battery> GetBatteries();
    }


    public class BatteriesRepository : IBatteriesRepository
    {

        public void AddBattery(Battery battery)
        {
            using (var db = new Context())
            {
                db.Batteries.Add(battery);
                db.SaveChanges();
            }
        }

        public List<Battery> GetBatteries()
        {
            using (var db = new Context())
            {
                var batteries = (from entity in db.Batteries
                             select entity).ToList();
                return batteries;
            }
        }
    }
}