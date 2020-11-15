using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceModules
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IdbOperations>().To<dbOperations>().InSingletonScope();
          
        }
    }
}
