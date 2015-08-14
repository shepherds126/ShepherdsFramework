﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Core.Infrastructure;
using ShepherdsFramework.Service.Customers;

namespace ShepherdsFramework.Framework
{
    /// <summary>
    /// 业务逻辑注入
    /// </summary>
   public class DependencyRegistrar:IDependencyRegistrar
    {
       public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
       {
           //webworkcontenxt 上下文注入
           builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
           builder.RegisterType<CustomerService>().As<ICustomersService>().InstancePerLifetimeScope();

           //所有的controllers 注入
           builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
       }

       public int Order
       {
           get { return 0; }
       }


    }
}
