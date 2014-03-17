using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using DataLayer.Repositories;

namespace ServiceLayer
{
    public interface IMemoryCardsService
    {
        void AddMemoryCard(MemoryCard memoryCard);
        List<MemoryCard> GetMemoryCards();
        MemoryCard GetMemoryCard(int id);
    }



    public class MemoryCardsService : IMemoryCardsService
    {

        private readonly IGoodsRepository _repository;

        public MemoryCardsService(IGoodsRepository repository)
        {
            this._repository = repository;
        }

        public void AddMemoryCard(MemoryCard memoryCard)
        {
            _repository.AddMemoryCard(memoryCard);
        }

        public List<MemoryCard> GetMemoryCards()
        {
            var goods = _repository.GetGoods();

            var memorycards = from entity in goods
                              where entity.Category == "MemoryCards"
                              select entity;
            var listReturn = new List<MemoryCard>();

            foreach (var item in memorycards)
            {
                var memoryCard = new MemoryCard()
                {
                    Id = item.Id,
                    Model = item.Model,
                    Producer = item.Producer,
                    Price = item.Price,
                };

                foreach (var prop in item.Properties.Where(prop => prop.Name == "Size"))
                {
                    memoryCard.Size = prop.ValueInt;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "WriteSpeed"))
                {
                    memoryCard.WriteSpeed = prop.ValueInt;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "ReadSpeed"))
                {
                    memoryCard.ReadSpeed = prop.ValueInt;
                }
                listReturn.Add(memoryCard);
            }
            return listReturn;
        }


        public MemoryCard GetMemoryCard(int id)
        {
            var goods = _repository.GetGoods();

            var item = (from entity in goods
                        where entity.Id == id
                        where entity.Category == "MemoryCards"
                        select entity).FirstOrDefault();
            if (item == null) return null;
            var memoryCard = new MemoryCard()
            {
                Id = item.Id,
                Model = item.Model,
                Producer = item.Producer,
                Price = item.Price,
            };

            foreach (var prop in item.Properties.Where(prop => prop.Name == "Size"))
            {
                memoryCard.Size = prop.ValueInt;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "WriteSpeed"))
            {
                memoryCard.WriteSpeed = prop.ValueInt;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "ReadSpeed"))
            {
                memoryCard.ReadSpeed = prop.ValueInt;
            }


            return memoryCard;

        }
    }
}