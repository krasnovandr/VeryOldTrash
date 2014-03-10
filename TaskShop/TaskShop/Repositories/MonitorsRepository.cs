using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskShop.Models;

namespace TaskShop.Repositories
{
    public interface IMonitorsRepository
    {
        void AddMonitor(Monitor battery);
        List<Monitor> GetMonitors();
    }


    public class MonitorsRepository : IMonitorsRepository
    {

        public void AddMonitor(Monitor monitor)
        {
            using (var db = new ShopContext())
            {
                db.Monitors.Add(monitor);
                db.SaveChanges();
            }
        }

        public List<Monitor> GetMonitors()
        {
            using (var db = new ShopContext())
            {
                var monitors = (from entity in db.Monitors
                                 select entity).ToList();
                return monitors;
            }
        }
    }
}