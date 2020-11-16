using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace DeliveryService
{
    public static class IoC
    {
        private static IKernel Kernel = new StandardKernel(new NinjectRegistrations());

        public static T Get<T>(params IParameter[] parameters)
        {
            return Kernel.Get<T>(parameters);
        }
    }
}
