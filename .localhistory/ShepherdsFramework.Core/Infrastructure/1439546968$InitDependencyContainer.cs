using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
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
        }
    }
}
