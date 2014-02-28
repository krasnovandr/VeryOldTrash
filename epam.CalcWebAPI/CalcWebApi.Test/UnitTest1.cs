using System;
using CalcWebAPI.Controllers;
using CalcWebAPI.Models;
using CalcWebAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Microsoft.Practices.Unity;
namespace CalcWebApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        private UnityContainer unityContainer;
        private IServiceCalculatorMemory service;
        private Model model;
        ValuesController controller;
       
        [TestInitialize()]
        public void MyTestInitialize()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IServiceCalculatorMemory, ServiceCalculatorMemory>();
            unityContainer.RegisterType<ICalculatorMemoryRepository, CalculatorMemoryRepository>();
            IServiceCalculatorMemory service = unityContainer.Resolve<ServiceCalculatorMemory>();
            model = new Model();
            controller = new ValuesController(service);

        }

        [TestMethod]
        public void GeTMR_ShouldReturnedValueFromMemory()
        {
            model.Current = 2;
            controller.PostMS(model);

            var result = controller.GetMR();
            Assert.AreEqual(model.Current, result);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException ))]
        public void GeTMR_ShouldFailed()
        {
            model.Current = 2;
            controller.PostMS(model);

            var result = controller.GetMR();
            model.Current = 3;
            Assert.AreEqual(model.Current, result);
        }



        [TestMethod]
        public void PostMplus_ShouldReturnedAdditedValue()
        {
            int test = model.Current = 2;
            test += test;
            controller.PostMS(model);

            var result = controller.PostMplus(model);
            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void PostMminus_ShouldReturnedSubtractingValue()
        {
            int test = model.Current = 2;
            test -= test;

            controller.PostMS(model);

            var result = controller.PostMinus(model);
            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void PostMC_ShouldReturnedNull()
        {
            model.Current = 0;
            var result = controller.PostMC(model);
            Assert.AreEqual(0, result);
        }


    }
}
