using Data;
using Service.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Service.Product;
using Data.Entities;

namespace Service.Configuration
{
    public class AutofacContainerBuilder
    {
        public static ContainerBuilder BuildContainer()
        {
            var builder = new ContainerBuilder();

            #region Data layer
            builder.Register<IDbContext>(m => new TestDbContext());
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>));
            #endregion

            #region service region
            builder.RegisterType<ChatService>().As<IChatService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<Notification>().As<INotification>().InstancePerRequest();
            #endregion

            return builder;
        }

    }
}
