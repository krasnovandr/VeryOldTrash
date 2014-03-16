using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shared;
using TaskShop.Repositories;

namespace TaskShop.Services
{
    public interface IEarponesService
    {
        void AddEarphone(Earphone earphone);
        List<Earphone> GetEarphones();
        Earphone GetEarphone(int id);
    }



    public class EarponesService : IEarponesService
    {

        private readonly IGoodsRepository _repository;

        public EarponesService(IGoodsRepository repository)
        {
            this._repository = repository;
        }

        public void AddEarphone(Earphone earphone)
        {
            _repository.AddEarphone(earphone);
        }

        public List<Earphone> GetEarphones()
        {
            var goods = _repository.GetGoods();

            var earphones = from entity in goods
                            where entity.Category == "Earphones"
                            select entity;
            var listReturn = new List<Earphone>();

            foreach (var item in earphones)
            {
                var earphone = new Earphone()
                {
                    Id = item.Id,
                    Model = item.Model,
                    Producer = item.Producer,
                    Price = item.Price,
                };
   
                foreach (var prop in item.Properties.Where(prop => prop.Name == "CableLength"))
                {
                    earphone.CableLength = prop.ValueInt;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "Resistance"))
                {
                    earphone.Resistance = prop.ValueInt;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "MaxFrequency"))
                {
                    earphone.MaxFrequency = prop.ValueInt;
                }
                listReturn.Add(earphone);
            }
            return listReturn;
        }


        public Earphone GetEarphone(int id)
        {
            var goods = _repository.GetGoods();

            var item = (from entity in goods
                        where entity.Id == id
                        select entity).FirstOrDefault();
          
            var earphone = new Earphone()
            {
                Id = item.Id,
                Model = item.Model,
                Producer = item.Producer,
                Price = item.Price,
            };

            foreach (var prop in item.Properties.Where(prop => prop.Name == "CableLength"))
            {
                earphone.CableLength = prop.ValueInt;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "Resistance"))
            {
                earphone.Resistance = prop.ValueInt;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "MaxFrequency"))
            {
                earphone.MaxFrequency = prop.ValueInt;
            }

            return earphone;

        }
    }
}