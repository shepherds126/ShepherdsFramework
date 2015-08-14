using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ShepherdsFramework.Core.Infrastructure;

namespace ShepherdsFramework.Core.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 通过ContainerBuilder注册依赖关系
        /// </summary>
        /// <param name="builder">容器管理者类</param>
        /// <param name="typeFinder">类型查找接口</param>
        void Register(ContainerBuilder builder,ITypeFinder typeFinder);
        int Order { get;  }
    }
}
