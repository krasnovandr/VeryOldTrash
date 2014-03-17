using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repositories;

namespace ServiceLayer
{
    public interface IHomeService
    {
        List<ReturnSearchModel> GetAll();
    }

    public class HomeService : IHomeService
    {
        private readonly IGoodsRepository _repository;

        public HomeService(IGoodsRepository repository)
        {
            this._repository = repository;
        }
 
        public List<ReturnSearchModel> GetAll()
        {
            var items = _repository.GetGoods();
          
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
