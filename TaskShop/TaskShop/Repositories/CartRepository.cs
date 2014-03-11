using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using TaskShop.Models;

namespace TaskShop.Repositories
{

    public interface ICartRepository
    {
        void AddBattery(Battery battery);
        void AddMonitor(Monitor monitor);
        List<Cart> GetCarts();
        bool Delete(int id);
    }


    public class CartRepository : ICartRepository
    {

        public void AddBattery(Battery battery)
        {
            using (var db = new ShopContext())
            {
                var cart = new Cart
                {
                    GoodsId = battery.Id,
                    GoodsCategory = "battery",
                    Price = battery.Price
                };
                db.Carts.Add(cart);
                db.SaveChanges();
            }
        }

        public void AddMonitor(Monitor monitor)
        {
            using (var db = new ShopContext())
            {
                var cart = new Cart
                {
                    GoodsId = monitor.Id,
                    GoodsCategory = "monitor",
                    Price = monitor.Price
                };
                db.Carts.Add(cart);
                db.SaveChanges();
            }

        }

        public List<Cart> GetCarts()
        {
            using (var db = new ShopContext())
            {
                var carts = (from entity in db.Carts
                             select entity).ToList();
                return carts;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new ShopContext())
            {
                var cart = db.Carts.Find(id);
                db.Carts.Remove(cart);
                db.SaveChanges();
                return cart!=null;
   
            }

        }

    }
}