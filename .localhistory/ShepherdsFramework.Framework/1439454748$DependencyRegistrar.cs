using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Core.Infrastructure;
using ShepherdsFramework.Data;
using ShepherdsFramework.Service.Customers;

namespace ShepherdsFramework.Framework
{
    /// <summary>
    /// 业务逻辑注入
    /// </summary>
   public class DependencyRegistrar:IDependencyRegistrar
    {
       public static void Register(ContainerBuilder builder, ITypeFinder typeFinder)
       {
           //webworkcontenxt 上下文注入
           builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
           //bll 注入
           builder.RegisterType<CustomerService>().As<ICustomersService>().InstancePerLifetimeScope();

           //所有的controllers 注入
           builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

           //数据层注入
           //泛型注入
           builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
       }

       public int Order
       {
           get { return 0; }
       }


    }
}
