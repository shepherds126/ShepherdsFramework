using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ShepherdsFramework.Core.DependencyManagement
{
    public class ContainerManager
    {
        private static IContainer _container;

        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        public virtual IContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// 按类型获取组件
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return ResolutionExtensions.Resolve<T>(_container);
        }
        /// <summary>
        /// 根据参数解析组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T Resolve<T>(params Autofac.Core.Parameter[] parameters)
        {
            return ResolutionExtensions.Resolve<T>(_container, parameters);
        }
        /// <summary>
        /// 根据key解析组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T ResolveKey<T>(object key)
        {
            return ResolutionExtensions.ResolveKeyed<T>(_container,key);
        }
        /// <summary>
        /// 根据name解析组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T ResolveNamed<T>(string name)
        {
            return ResolutionExtensions.ResolveNamed<T>(_container, name);
        }
    }
}
