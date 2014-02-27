using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CalcWebAPI.Models;
using CalcWebAPI.Services;

namespace CalcWebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        private IServiceCalculatorMemory service;

        public ValuesController(IServiceCalculatorMemory service)
        {
            this.service = service;
        }

        public int PostMS([FromBody]Model model)
        {
            return service.PostMS(model);
        }

        public int PostMC([FromBody]Model model)
        {
            return service.PostMC(model);
        }

        public int PostMplus([FromBody]Model model)
        {
            return service.PostMplus(model);
        }

        public int PostMinus([FromBody]Model model)
        {
            return service.PostMinus(model);
        }

        public int GetMR()
        {
            return service.GetMR();
        }
    }
}