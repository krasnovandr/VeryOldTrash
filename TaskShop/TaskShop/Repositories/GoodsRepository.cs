using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using TaskShop.Models;
using Shared;


namespace TaskShop.Repositories
{
    public interface IGoodsRepository
    {
        List<Commodity> GetGoods();
        
        void AddBattery(Battery battery);
        void AddMonitor(Monitor monitor);
        void AddMemoryCard(MemoryCard memoryCard);
        void AddEarphone(Earphone earphone);
    }

    public class GoodsRepository : IGoodsRepository
    {
        public List<Commodity> GetGoods()
        {
            using (var db = new ShopContext())
            {
                var goods = db.DbGoods.Include(p => p.Properties).ToList();
                return goods;
            }
        }

        public void AddBattery(Battery battery)
        {
            using (var db = new ShopContext())
            {
                var prop = new Property
                {
                    Name = "Capacity",
                    ValueInt = battery.Capacity,
                };
                
                var prop2 = new Property
                {
                    Name = "Voltage",
                    ValueInt = battery.Voltage,
                };

                var item = new Commodity
                {
                    Model = battery.Model,
                    Price = battery.Price,
                    Producer = battery.Producer,
                    Category = "Batteries"
                };

                db.DbGoods.Add(item);
                prop.Goods.Add(item);
                prop2.Goods.Add(item);
                db.DbProperties.Add(prop);
                db.DbProperties.Add(prop2);
                db.SaveChanges();

            }
        }

        public void AddMonitor(Monitor monitor)
        {
            using (var db = new ShopContext())
            {
                var resolution = new Property
                {
                    Name = "Resolution",
                    ValueChar = monitor.Resolution,
                };

                var   frequency = new Property
                {
                    Name = "Frequency",
                    ValueInt = monitor.Frequency,
                };

                var   matrixType = new Property
                {
                    Name = "MatrixType",
                    ValueChar = monitor.MatrixType,
                };


                var item = new Commodity
                {
                    Model = monitor.Model,
                    Price = monitor.Price,
                    Producer = monitor.Producer,
                    Category = "Monitors"
                };

                db.DbGoods.Add(item);
                resolution.Goods.Add(item);
                frequency.Goods.Add(item);
                matrixType.Goods.Add(item);

                db.DbProperties.Add(resolution);
                db.DbProperties.Add(frequency);
                db.DbProperties.Add(matrixType);
                db.SaveChanges();

            }
        }
    
        public void AddMemoryCard(MemoryCard memoryCard)
        {
            using (var db = new ShopContext())
            {
                var size = new Property
                {
                    Name = "Size",
                    ValueInt = memoryCard.Size,
                };

                var writeSpeed = new Property
                {
                    Name = "WriteSpeed",
                    ValueInt = memoryCard.WriteSpeed,
                };

                var readSpeed = new Property
                {
                    Name = "ReadSpeed",
                    ValueInt = memoryCard.ReadSpeed,
                };


                var item = new Commodity
                {
                    Model = memoryCard.Model,
                    Price = memoryCard.Price,
                    Producer = memoryCard.Producer,
                    Category = "MemoryCards"
                };

                db.DbGoods.Add(item);
                writeSpeed.Goods.Add(item);
                readSpeed.Goods.Add(item);
                size.Goods.Add(item);

                db.DbProperties.Add(size);
                db.DbProperties.Add(readSpeed);
                db.DbProperties.Add(writeSpeed);
                db.SaveChanges();

            }
        }
        
        public void AddEarphone(Earphone earphone)
        {
            using (var db = new ShopContext())
            {
                var maxFrequency = new Property
                {
                    Name = "MaxFrequency",
                    ValueInt = earphone.MaxFrequency,
                };

                var resistance = new Property
                {
                    Name = "Resistance",
                    ValueInt = earphone.Resistance,
                };

                var cableLength = new Property
                {
                    Name = "CableLength",
                    ValueInt = earphone.CableLength,
                };


                var item = new Commodity
                {
                    Model = earphone.Model,
                    Price = earphone.Price,
                    Producer = earphone.Producer,
                    Category = "Earphones"
                };

                db.DbGoods.Add(item);
                cableLength.Goods.Add(item);
                resistance.Goods.Add(item);
                maxFrequency.Goods.Add(item);

                db.DbProperties.Add(maxFrequency);
                db.DbProperties.Add(resistance);
                db.DbProperties.Add(cableLength);
                db.SaveChanges();

            }
        }
    }
}