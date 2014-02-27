using System;
using CalcWebAPI.Controllers;
using CalcWebAPI.Models;
using CalcWebAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
namespace CalcWebApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GeTMR_ShouldReturnedValueFromMemory()
        {
            var rep = new CalculatorMemoryRepository();
            var service = new ServiceCalculatorMemory(rep);
            var model = new Model();
            model.Current = 2;

            var controller = new ValuesController(service);
            controller.PostMS(model);

            var result = controller.GetMR();
            Assert.AreEqual(model.Current, result);
        }


        [TestMethod]
        public void PostMplus_ShouldReturnedAdditedValue()
        {
            var rep = new CalculatorMemoryRepository();
            var service = new ServiceCalculatorMemory(rep);
            var model = new Model();
            int test = model.Current = 2;
            test += test; 

            var controller = new ValuesController(service);
            controller.PostMS(model);

            var result = controller.PostMplus(model);
            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void PostMminus_ShouldReturnedSubtractingValue()
        {
            var rep = new CalculatorMemoryRepository();
            var service = new ServiceCalculatorMemory(rep);
            var model = new Model();
            int test = model.Current = 2;
            test -= test;

            var controller = new ValuesController(service);
            controller.PostMS(model);

            var result = controller.PostMinus(model);
            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void PostMC_ShouldReturnedNull()
        {
            var rep = new CalculatorMemoryRepository();
            var service = new ServiceCalculatorMemory(rep);
            var model = new Model();
            model.Current = 0;
            var controller = new ValuesController(service);


            var result = controller.PostMC(model);
            Assert.AreEqual(0, result);
        }


    }
}
