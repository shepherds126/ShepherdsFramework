using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Infrastructure
{
    public interface ITypeFinder
    {
        /// <summary>
        /// 获取所有的程序集
        /// </summary>
        /// <returns></returns>
        IList<Assembly> GetAssemblies();
    }
}
