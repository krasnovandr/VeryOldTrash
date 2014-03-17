using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using DataLayer.Repositories;

namespace ServiceLayer
{
    public interface IBatteriesService
    {
        void AddBattery(Battery battery);
        List<Battery> GetBatteries();
        Battery GetBattery(int id);
    }



    public class BatteriesService : IBatteriesService
    {

        private readonly IGoodsRepository _repository;

        public BatteriesService(IGoodsRepository repository)
        {
            this._repository = repository;
        }

        public void AddBattery(Battery battery)
        {
            _repository.AddBattery(battery);
        }

        public List<Battery> GetBatteries()
        {
            var goods = _repository.GetGoods();

            var batteries = from entity in goods
                            where entity.Category == "Batteries"
                            select entity;
            var listReturn = new List<Battery>();

            foreach (var item in batteries)
            {
                var battery = new Battery()
                {
                    Id = item.Id,
                    Model = item.Model,
                    Producer = item.Producer,
                    Price = item.Price,

                    //Voltage = item.Properties[],
                    //Capacity = item.Properties.Select()

                };
                foreach (var prop in item.Properties.Where(prop => prop.Name == "Capacity"))
                {
                    battery.Capacity = prop.ValueInt;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "Voltage"))
                {
                    battery.Voltage = prop.ValueInt;
                }

                listReturn.Add(battery);
            }
            return listReturn;
        }


        public Battery GetBattery(int id)
        {
            var goods = _repository.GetGoods();

            var item = (from entity in goods
                        where entity.Id == id
                        where entity.Category == "Batteries"
                        select entity).FirstOrDefault();
            if (item == null) return null;
            var battery = new Battery()
            {
                Id = item.Id,
                Model = item.Model,
                Producer = item.Producer,
                Price = item.Price,
            };
            foreach (var prop in item.Properties.Where(prop => prop.Name == "Capacity"))
            {
                battery.Capacity = prop.ValueInt;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "Voltage"))
            {
                battery.Voltage = prop.ValueInt;
            }
            return battery;

        }
    }
}