using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.Caching;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Core.Infrastructure;
using ShepherdsFramework.Data;
using ShepherdsFramework.Framework.Utilities.Captcha;
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
           //bll 注入
           builder.RegisterType<CustomerService>().As<ICustomersService>().InstancePerLifetimeScope();
           //验证码管理器
           builder.RegisterType<DefaultCaptchaManager>().As<ICaptchaManager>().SingleInstance();
           //缓存注册
           builder.Register(c => new DefaultCacheService(new RuntimeMemoryCache(), 1.0f))
               .As<ICacheService>()
               .SingleInstance();

           //所有的controllers 注入
           builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

           //数据层注入

           var configstrategy = new ConfigStrategy();
           var RDBSConfigInfo = configstrategy.GetRDBSConfigInfo();
           builder.Register<IDbContext>(
               c => new ShepherdsFrameworkDbContext(RDBSConfigInfo.RDBSConnectionString))
               .InstancePerLifetimeScope();
           //泛型注入
           builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
       }

       public int Order
       {
           get { return 0; }
       }


    }
}
