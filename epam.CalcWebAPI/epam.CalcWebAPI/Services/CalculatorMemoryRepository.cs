using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcWebAPI.Services
{  
    public static class CalculatorMemory
    {
        public static int memory;
    }
    
    public interface ICalculatorMemoryRepository
    {
        int GetMemory();
        void SetMemory(int value);
    }
  


    public class CalculatorMemoryRepository : ICalculatorMemoryRepository
    {
        public int GetMemory()
        {
            return CalculatorMemory.memory;
        }

        public void SetMemory(int value)
        {
            CalculatorMemory.memory = value;
        }
    }
}