using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskShop.Models;
using TaskShop.Shared;


namespace TaskShop.Repositories
{
    public interface IGoodsRepository
    {
        List<Commodity> GetGoods();
        
        void AddBattery(Battery battery);
    }

    public class GoodsRepository : IGoodsRepository
    {
        public List<Commodity> GetGoods()
        {
            using (var db = new ShopContext())
            {
                var goods = db.DbGoods.Include(p => p.Properties).ToList();
                return goods;
            }
        }

        public void AddBattery(Battery battery)
        {
            using (var db = new ShopContext())
            {
                var prop = new Property
                {
                    Name = "Capacity",
                    ValueInt = battery.Capacity,
                };
                
                var prop2 = new Property
                {
                    Name = "Voltage",
                    ValueInt = battery.Voltage,
                };

                var item = new Commodity();

                item.Model = battery.Model;
                item.Price = battery.Price;
                item.Producer = battery.Producer;
                item.Category = "Batteries";
             


                db.DbGoods.Add(item);
                prop.Goods.Add(item);
                prop2.Goods.Add(item);
                db.DbProperties.Add(prop);
                db.DbProperties.Add(prop2);
                db.SaveChanges();

            }
        }

    }
}