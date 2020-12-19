using DAL.Interfaces;
using DAL.Repositories;
using BLL.Interfaces;
using BLL;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;

namespace BLL.ServiceModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IdbOperations>().To<dbReposSQL>().InSingletonScope();
            Bind<IdbCrud>().To<dbOperations>().InSingletonScope();
            Bind<ICourierSalary>().To<CourierSalary>().InSingletonScope();
            Bind<IReportsReprository>().To<ReportRepository>().InSingletonScope();
        }

    }
}
