using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TaskShop.Repositories;
using TaskShop.Services;
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

            container.RegisterType<IBatteriesService, BatteriesService>();
            container.RegisterType<IMonitorsService, MonitorsService>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<IEarponesService, EarponesService>();
            container.RegisterType<IMemoryCardsService, MemoryCardsService>();

            container.RegisterType<IGoodsRepository, GoodsRepository>();
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<IOrdersRepository, OrdersRepository>();
    
            return container;
        }
    }
}