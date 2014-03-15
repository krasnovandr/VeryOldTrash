using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskShop.Models;
using TaskShop.Shared;

namespace TaskShop.Repositories
{

    public interface ISearchRepository
    {
        //void AddOrder(Order order, List<Cart> listGoods);
        //List<Order> GetOrders();
        //OrderAndGoods GetOrder(int id);
        List<SearchModel> GetAll(string modelName);
    }

    public class SearchRepository : ISearchRepository
    {
        public List<SearchModel> GetAll(string modelName)
        {
            using (var db = new ShopContext())
            {
                //var batteries = (from entity in db.Batteries
                //                 where entity.Model.Contains(modelName)
                //                 select entity).ToList();
                //var monitors = (from entity in db.Monitors
                //                where entity.Model.Contains(modelName)
                //                select entity).ToList();

                //var list = batteries.Select(item => new SearchModel
                //{
                //    GoodsCategory = "Batteries", GoodsId = item.Id, Price = item.Price, Model = item.Model, Producer = item.Producer
                //}).ToList();
                //list.AddRange(monitors.Select(item => new SearchModel
                //{
                //    GoodsCategory = "Monitors", GoodsId = item.Id, Price = item.Price, Model = item.Model, Producer = item.Producer
                //}));


                return null;
            }
        }
    }
}