using AccountAtAGlance.Controllers;
using AccountAtAGlance.Repository;
using AccountAtAGlance.Repository.Helpers;
using Microsoft.Practices.Unity;

namespace AccountAtAGlance.IoC
{
    public static class IoCMappingContainer
    {
        private static IUnityContainer _Instance = new UnityContainer();
        static IoCMappingContainer() { }
        public static IUnityContainer GetInstance()
        {
            _Instance.RegisterType<DataServiceController>();
            _Instance.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
            _Instance.RegisterType<ISecurityRepository, SecurityRepository>(new HierarchicalLifetimeManager());
            _Instance.RegisterType<IMarketsAndNewsRepository, MarketsAndNewsRepository>(new HierarchicalLifetimeManager());
            _Instance.RegisterType<IStockEngine, StockEngine>(new HierarchicalLifetimeManager());
            return _Instance;
        }
    }
}
