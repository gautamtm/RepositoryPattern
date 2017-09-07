using Autofac;
using Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Test.Configuration
{
    public class AutofacContainerBuilder
    {
        public static ContainerBuilder BuildContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<ProductTest>().As<ProductTest>().InstancePerRequest();

            return builder;
        }

    }
}
