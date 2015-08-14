using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Core.Infrastructure;

namespace ShepherdsFramework.Framework
{
   public class DependencyRegistrar:IDependencyRegistrar
    {
       public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
       {
           builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
       }

      
    }
}
