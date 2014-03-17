using System.Web.Mvc;
using DataLayer.Repositories;
using Microsoft.Practices.Unity;
using ServiceLayer;
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
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IHomeService, HomeService>();

            container.RegisterType<IGoodsRepository, GoodsRepository>();
            container.RegisterType<IOrdersRepository, OrdersRepository>();

            return container;
        }
    }
}