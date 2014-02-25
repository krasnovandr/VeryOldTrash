using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using epam.CalcWebAPI.Models;

namespace epam.CalcWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
  
        public string PostMS([FromBody]Model model)
        {
            CalculatorMemory.memory = model.Current;
            return model.Current.ToString();
        }

        public string PostMC([FromBody]Model model)
        {
            CalculatorMemory.memory = model.Current;
            return model.Current.ToString();
        }


        public string PostMplus([FromBody]Model model)
        {
            return (CalculatorMemory.memory += model.Current).ToString();
        }

        public string PostMinus([FromBody]Model model)
        {
            return (CalculatorMemory.memory -= model.Current).ToString();
        }


        public string GetMR()
        {
            return CalculatorMemory.memory.ToString();
        }


        public string PostDigit([FromBody]Model model)
        {


            return model.Current.ToString();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}