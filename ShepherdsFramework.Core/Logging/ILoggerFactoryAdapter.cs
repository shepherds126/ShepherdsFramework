using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Logging
{
    /// <summary>
    /// 供LoggerFactory使用的适配器接口
    /// </summary>
    public interface ILoggerFactoryAdapter
    {
        /// <summary>
        /// 依据日志名称获取
        /// </summary>
        /// <param name="loggerName">日志名称</param>
        /// <returns></returns>
         ILogger GetLogger(string loggerName);
    }
}
