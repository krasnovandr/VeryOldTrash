using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using epam.CalcWebAPI.Models;

namespace epam.CalcWebAPI.Services
{
    public interface IServiceCalculatorMemory
    {
        string PostMS(Model model);

        string PostMC(Model model);

        string PostMplus(Model model);

        string PostMinus(Model model);

        string GetMR();
    }

    public class ServiceCalculatorMemory : IServiceCalculatorMemory
    {
        private CalculatorMemoryRepository repository;

        public ServiceCalculatorMemory()
        {
            this.repository = new CalculatorMemoryRepository();
        }

        public string PostMS(Model model)
        {
            repository.SetMemory(model.Current);
            return repository.GetMemory().ToString();
        }

        public string PostMC(Model model)
        {
            repository.SetMemory(model.Current);
            return repository.GetMemory().ToString();
        }


        public string PostMplus(Model model)
        {
            int value = repository.GetMemory();
            value += model.Current;
            repository.SetMemory(value);
            return repository.GetMemory().ToString();
        }

        public string PostMinus(Model model)
        {
            int value = repository.GetMemory();
            value -= model.Current;
            repository.SetMemory(value);
            return repository.GetMemory().ToString();
        }

        public string GetMR()
        {
            return repository.GetMemory().ToString();
        }

    }
}