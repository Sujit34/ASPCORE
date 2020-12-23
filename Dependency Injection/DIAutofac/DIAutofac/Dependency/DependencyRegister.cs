using Autofac;
using DIAutofac.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIAutofac.Dependency
{
    public class DependencyRegister : Module
    {      
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope();
            return builder.Build();
        }

        
    }
}
