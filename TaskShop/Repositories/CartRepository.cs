using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using TaskShop.Models;
using TaskShop.Shared;


namespace TaskShop.Repositories
{

    public interface ICartRepository
    {
        void AddBattery(Battery battery, List<Cart> list);
        void AddMonitor(Monitor monitor, List<Cart> list);
        //List<Cart> GetCarts();
        void Delete(Cart cart, List<Cart> list);
    }


    public class CartRepository : ICartRepository
    {

        public void AddBattery(Battery battery, List<Cart> list)
        {
            var cart = new Cart
            {
                GoodsId = battery.Id,
                GoodsCategory = "Batteries",
                Price = battery.Price,
                Count = 1
            };
            var flg = 1;
            foreach (Cart item in list)
            {
                if (item.GoodsId == battery.Id && item.GoodsCategory == "Batteries")
                {
                    item.Count++;
                    flg = 0;
                    break;

                }
            }
            if (flg == 1)
            {
                list.Add(cart);
            }
        }


        //public void AddBattery(Battery battery)
        //{

        //    using (var db = new ShopContext())
        //    {
        //        var tmp = (from entity in db.Carts
        //                   where entity.GoodsId == battery.Id
        //                   where entity.GoodsCategory == "battery"
        //                   select entity).FirstOrDefault();

        //        if (tmp == null)
        //        {
        //            var cart = new Cart
        //            {
        //                GoodsId = battery.Id,
        //                GoodsCategory = "battery",
        //                Price = battery.Price,
        //                Count = 1
        //            };
        //            db.Carts.Add(cart);

        //        }
        //        else
        //        {
        //            tmp.Count++;
        //            db.Entry(tmp).State = EntityState.Modified;

        //        }
        //        db.SaveChanges();
        //    }
        //}

        public void AddMonitor(Monitor monitor, List<Cart> list)
        {
            var cart = new Cart
            {
                GoodsId = monitor.Id,
                GoodsCategory = "Monitors",
                Price = monitor.Price,
                Count = 1
            };
            var flg = 1;
            foreach (Cart item in list)
            {
                if (item.GoodsId == monitor.Id && item.GoodsCategory == "Monitors")
                {
                    item.Count++;
                    flg = 0;
                    break;

                }
            }
            if (flg == 1)
            {
                list.Add(cart);
            }

        }

        //public List<Cart> GetCarts()
        //{
        //    using (var db = new ShopContext())
        //    {
        //        var carts = (from entity in db.Carts
        //                     select entity).ToList();
        //        return carts;
        //    }
        //}

        public void Delete(Cart cart, List<Cart> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (cart.GoodsCategory == list[i].GoodsCategory && cart.GoodsId == list[i].GoodsId)
                {
                    switch (list[i].Count)
                    {
                        case 1:
                            list.RemoveAt(i);
                            break;
                        default:
                            list[i].Count--;
                            break;
                    }
                }
            }
            //using (var db = new ShopContext())
            //{
            //    var tmp = (from entity in db.Carts
            //               where entity.Id == id
            //               select entity).FirstOrDefault();
            //    if (tmp.Count == 1)
            //    {
            //        db.Carts.Remove(tmp);
            //    }
            //    else
            //    {
            //        tmp.Count--;
            //        db.Entry(tmp).State = EntityState.Modified;
            //    }

            //    db.SaveChanges();

            //}
        }
    }
}