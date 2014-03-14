using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

using TaskShop.Models;

namespace TaskShop.Repositories
{
    public interface IOrdersRepository
    {
        void AddOrder(Order order, List<Cart> listGoods);
        List<Order> GetOrders();
    }

    public class OrdersRepository : IOrdersRepository
    {

        public void AddOrder(Order order, List<Cart> listGoods)
        {
            using (var db = new ShopContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();

                var email = order.Email;
                const string subject = "Your Order Id";

                var text = "Your Order Id:" + Environment.NewLine + order.Id;
                MailSender.sendMail(subject, email, text);

                foreach (var item in listGoods)
                {
                    item.OrderId = order.Id;
                    db.Carts.Add(item);
                }
                db.SaveChanges();

            }
        }

        public List<Order> GetOrders()
        {
            using (var db = new ShopContext())
            {
                var orders = (from entity in db.Orders
                              select entity).ToList();
                return orders;
            }
        }

    }
}