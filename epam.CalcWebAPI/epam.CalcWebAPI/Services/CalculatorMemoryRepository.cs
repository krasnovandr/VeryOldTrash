using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CalcWebAPI.Services
{
    public class Memory
    {
        [Key]
        public int ID { get; set; }
        public int memory { get; set; }
    }

    public class MemoryContext : DbContext
    {
        public DbSet<Memory> Memory { get; set; }
    }

    public interface ICalculatorMemoryRepository
    {
        int GetMemory();
        void SetMemory(int value);
    }


    public class CalculatorMemoryRepository : ICalculatorMemoryRepository
    {

        //public CalculatorMemoryRepository()
        //{
        //    using (var db = new MemoryContext())
        //    {
        //        Memory mem = new Memory();
        //        mem.memory = 0;
        //        db.Memory.Add(mem);
        //        db.SaveChanges();
        //    }
        //}


        public int GetMemory()
        {
            using (var db = new MemoryContext())
            {
                var tmp = (from entity in db.Memory
                           where entity.ID == 1
                           select entity).First();
                return tmp.memory;

            }
        }

        public void SetMemory(int value)
        {
            using (var db = new MemoryContext())
            {
                var tmp = (from entity in db.Memory
                           where entity.ID == 1
                           select entity).First();

                {
                    tmp.memory = value;
                    //UpdateModel(tmp);
                    db.SaveChanges();
                }

            }
        }
    }
}