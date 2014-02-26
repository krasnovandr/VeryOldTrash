using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using epam.CalcWebAPI.Models;
using epam.CalcWebAPI.Services;

namespace epam.CalcWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        //private ICalculatorMemoryRepository _repository;

        //private ServiceCalculatorMemory service;
        private IServiceCalculatorMemory service;
        //public ValuesController(IServiceCalculatorMemory service)
        //{
        //    this.service = service;
        //}

        public ValuesController(IServiceCalculatorMemory service)
        {
            this.service = service;
        }

        public string PostMS([FromBody]Model model)
        {
            return service.PostMS(model);
        }

        public string PostMC([FromBody]Model model)
        {
            return service.PostMC(model);
        }

        public string PostMplus([FromBody]Model model)
        {
            return service.PostMplus(model);
        }

        public string PostMinus([FromBody]Model model)
        {
            return service.PostMinus(model);
        }

        public string GetMR()
        {
            return service.GetMR();
        }



        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}