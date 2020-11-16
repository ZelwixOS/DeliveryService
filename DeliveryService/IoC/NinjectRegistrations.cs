using Ninject.Modules;
using DeliveryService.Navigation;
using BLL.Interfaces;
using BLL;


namespace DeliveryService
{
    class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<INavigation>().To<MainNavigation>().InSingletonScope();
            Bind<IdbCrud>().To<dbOperations>();
        }
    }
}
