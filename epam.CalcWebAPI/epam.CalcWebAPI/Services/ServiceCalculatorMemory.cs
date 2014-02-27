using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcWebAPI.Models;

namespace CalcWebAPI.Services
{
    public interface IServiceCalculatorMemory
    {
        int PostMS(Model model);

        int PostMC(Model model);

        int PostMplus(Model model);

        int PostMinus(Model model);

        int GetMR();
    }

    public class ServiceCalculatorMemory : IServiceCalculatorMemory
    {
        private ICalculatorMemoryRepository repository;

        //public ServiceCalculatorMemory()
        //{
        //    this.repository = new CalculatorMemoryRepository();
        //}
        
        public ServiceCalculatorMemory(ICalculatorMemoryRepository repository)
        {
            this.repository = repository;
        }

        public int PostMS(Model model)
        {
            repository.SetMemory(model.Current);
            return repository.GetMemory();
        }

        public int PostMC(Model model)
        {
            repository.SetMemory(model.Current);
            return repository.GetMemory();
        }


        public int PostMplus(Model model)
        {
            int value = repository.GetMemory();
            value += model.Current;
            repository.SetMemory(value);
            return repository.GetMemory();
        }

        public int PostMinus(Model model)
        {
            int value = repository.GetMemory();
            value -= model.Current;
            repository.SetMemory(value);
            return repository.GetMemory();
        }

        public int GetMR()
        {
            return repository.GetMemory();
        }

    }
}