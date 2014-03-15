using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

using TaskShop.Models;

namespace TaskShop.Repositories
{
    public class OrderAndGoods
    {
        public Order Order { get; set; }
        public List<Cart> GoodsList { get; set; }
    }

    public interface IOrdersRepository
    {
        void AddOrder(Order order, List<Cart> listGoods);
        List<Order> GetOrders();
        OrderAndGoods GetOrder(int id);
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

        public OrderAndGoods GetOrder(int id)
        {
            using (var db = new ShopContext())
            {
                var orderAndGoods = new OrderAndGoods();
                var order = (from entity in db.Orders
                             where entity.Id == id
                             select entity).FirstOrDefault();
                orderAndGoods.Order = order;
                var goods = (from entity in db.Carts
                             where entity.OrderId == id
                             select entity).ToList();

                orderAndGoods.GoodsList = goods;
                return orderAndGoods;
            }
        }

    }
}