using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.DependencyManagement;

namespace ShepherdsFramework.Core.Logging
{
    /// <summary>
    /// 系统日志工厂
    /// </summary>
   public static class LoggerFactory
    {
       /// <summary>
       /// 利用日志名称获取
       /// </summary>
       /// <param name="loggername"></param>
       /// <returns></returns>
       public static ILogger GetLogger(string loggername)
       {
           return ContainerManager.Resolve<ILoggerFactoryAdapter>().GetLogger(loggername);
       }
        /// <summary>
        /// 获取name=sf的日志
        /// </summary>
        /// <returns></returns>
       public static ILogger GetLogger()
       {
           return LoggerFactory.GetLogger("sf");
       }
    }
}
