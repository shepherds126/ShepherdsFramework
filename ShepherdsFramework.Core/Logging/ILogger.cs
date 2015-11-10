using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Logging
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 检查level级别的日志是否启用
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnable(LogLevel level);
        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        void Log(LogLevel level,object message);
        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        void Log(LogLevel level,System.Exception exception,object message);
        
    }
}
