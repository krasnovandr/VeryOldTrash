using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TaskShop.Models;

namespace TaskShop.Repositories
{
    public interface IOrdersRepository
    {
        void AddOrder(Order order, List<Cart> listGoods);
        //List<Monitor> GetMonitors();
    }

    public class OrdersRepository : IOrdersRepository
    {

        public void AddOrder(Order order, List<Cart> listGoods)
        {
            using (var db = new ShopContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();


                foreach (var item in listGoods)
                {
                    item.OrderId = order.Id;
                    db.Carts.Add(item);
                }
                db.SaveChanges();
               
            }

        }

    }
}