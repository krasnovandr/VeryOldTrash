using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace epam.CalcWebAPI.Services
{
    //public interface ICalculatorMemoryRepository
    //{
    //    int GetMemory();
    //    void SetMemory(int value);
    //}
    public static class CalculatorMemory
    {
        public static int memory;
    }


    public class CalculatorMemoryRepository
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