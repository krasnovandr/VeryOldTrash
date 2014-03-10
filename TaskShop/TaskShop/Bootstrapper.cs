using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TaskShop.Repositories;
using Unity.Mvc3;

namespace TaskShop
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();            


            container.RegisterType<IBatteriesRepository, BatteriesRepository>();
            container.RegisterType<IMonitorsRepository, MonitorsRepository>();
            container.RegisterType<IMemoryCardsRepository, MemoryCardsRepository>();
            container.RegisterType<IEarphonesRepository, EarphonesRepository>();
            //container.RegisterType<IController, StoreController>("Store");
            return container;
        }
    }
}