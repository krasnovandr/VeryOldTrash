using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using DataLayer.Repositories;

namespace ServiceLayer
{
    public interface IMonitorsService
    {
        void AddMonitor(Monitor monitor);
        List<Monitor> GetMonitors();
        Monitor GetMonitor(int id);
    }

    public class MonitorsService : IMonitorsService
    {
        private readonly IGoodsRepository _repository;

        public MonitorsService(IGoodsRepository repository)
        {
            this._repository = repository;
        }

        public void AddMonitor(Monitor monitor)
        {
            _repository.AddMonitor(monitor);
        }

        public List<Monitor> GetMonitors()
        {
            var goods = _repository.GetGoods();

            var monitors = from entity in goods
                           where entity.Category == "Monitors"
                           select entity;
            var listReturn = new List<Monitor>();

            foreach (var item in monitors)
            {
                var monitor = new Monitor()
                {
                    Id = item.Id,
                    Model = item.Model,
                    Producer = item.Producer,
                    Price = item.Price,
                };
                foreach (var prop in item.Properties.Where(prop => prop.Name == "Resolution"))
                {
                    monitor.Resolution = prop.ValueChar;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "Frequency"))
                {
                    monitor.Frequency = prop.ValueInt;
                }
                foreach (var prop in item.Properties.Where(prop => prop.Name == "MatrixType"))
                {
                    monitor.MatrixType = prop.ValueChar;
                }
                listReturn.Add(monitor);
            }
            return listReturn;
        }


        public Monitor GetMonitor(int id)
        {
            var goods = _repository.GetGoods();

            var item = (from entity in goods
                        where entity.Id == id
                        where entity.Category == "Monitors"
                        select entity).FirstOrDefault();
            if (item == null) return null;
            var monitor = new Monitor()
            {
                Id = item.Id,
                Model = item.Model,
                Producer = item.Producer,
                Price = item.Price,
            };
            foreach (var prop in item.Properties.Where(prop => prop.Name == "Resolution"))
            {
                monitor.Resolution = prop.ValueChar;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "Frequency"))
            {
                monitor.Frequency = prop.ValueInt;
            }
            foreach (var prop in item.Properties.Where(prop => prop.Name == "MatrixType"))
            {
                monitor.MatrixType = prop.ValueChar;
            }

        
            return monitor;

        }
    }
}