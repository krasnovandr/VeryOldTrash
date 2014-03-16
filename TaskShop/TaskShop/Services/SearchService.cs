using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shared;
using TaskShop.Models;
using TaskShop.Repositories;

namespace TaskShop.Services
{
    public interface ISearchService
    {
        List<ReturnSearchModel> GetAll(SearchModel searchModel);
    }

    public class SearchService : ISearchService
    {
        private readonly IGoodsRepository _repository;

        public SearchService(IGoodsRepository repository)
        {
            this._repository = repository;
        }
        private List<Commodity> fieldSearch(SearchModel searchModel, List<Commodity> searchList)
        {

            var list = new List<Commodity>();
            if (searchModel.MaxPrice != 0 && searchModel.MinPrice != 0)
            {
                var tmp = (from entity in searchList
                           where entity.Price > searchModel.MinPrice
                           where entity.Price < searchModel.MaxPrice
                           select entity).ToList();
                list.AddRange(tmp);
            }
            if (searchModel.MaxPrice != 0)
            {
                var tmp = (from entity in searchList
                           where entity.Price <= searchModel.MaxPrice
                           select entity).ToList();
                list.AddRange(tmp);
            }
            if (searchModel.MinPrice != 0)
            {
                var tmp = (from entity in searchList
                           where entity.Price >= searchModel.MinPrice
                           select entity).ToList();
                list.AddRange(tmp);
            }

            if (searchModel.Model != null)
            {
                var tmp = (from entity in searchList
                           where entity.Model.ToUpper().Contains(searchModel.Model.ToUpper())
                           select entity).ToList();
                list.AddRange(tmp);
            }
            if (searchModel.Producer != null)
            {
                var tmp = (from entity in searchList
                           where entity.Producer.ToUpper().Contains(searchModel.Producer.ToUpper())
                           select entity).ToList();
                list.AddRange(tmp);
            }

            return list;
        }
        public List<Commodity> Search(SearchModel searchModel)
        {
            using (var db = new ShopContext())
            {
                var goods = _repository.GetGoods();
                if (searchModel.GoodsCategory == "All")
                {

                    return fieldSearch(searchModel, goods);
                }
                else
                {
                    var itemsInCategory = (from entity in goods
                                           where entity.Category == searchModel.GoodsCategory
                                           select entity).ToList();

                    if (searchModel.Model == null
                        && searchModel.MaxPrice == 0
                        && searchModel.MinPrice == 0
                        && searchModel.Producer == null)
                    {
                        return itemsInCategory;
                    }
                    else
                    {
                        return fieldSearch(searchModel, itemsInCategory);
                    }

                }
            }
        }
        public List<ReturnSearchModel> GetAll(SearchModel searchModel)
        {
            var items = Search(searchModel);
            var values = items.Select(item => new ReturnSearchModel
            {
                Model = item.Model,
                Price = item.Price,
                Producer = item.Producer,
                GoodsId = item.Id, 
                GoodsCategory = item.Category
            }).ToList();

            return values;
        }
    }

}