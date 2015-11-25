using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ShepherdsFramework.Core.DependencyManagement;

namespace ShepherdsFramework.Core.Infrastructure
{
    /// <summary>
    /// 依赖注入初始化器
    /// </summary>
    public class InitDependencyContainer
    {
        public static void InitContainer()
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            var typefinder = new WebAppDomainTypeFinder();
            
            builder = new ContainerBuilder();
            builder.RegisterInstance(typefinder).As<ITypeFinder>().SingleInstance();
            builder.Update(container);
            
            builder = new ContainerBuilder();
            var drtypes = typefinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drtype in drtypes)
            {
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drtype));
            }
            foreach (var dr in drInstances)
            {
                dr.Register(builder,typefinder);
            }
            
            builder.Update(container);
            //将Autofac容器中的实例注册到mvc自带的容器中
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            ContainerManager.RegisterContainer(container);
        }
    }
}
