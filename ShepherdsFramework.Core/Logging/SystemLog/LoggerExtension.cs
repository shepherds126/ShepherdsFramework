using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Logging.SystemLog
{
    /// <summary>
    /// ILogger扩展
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        /// 记录Debug级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Debug(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Debug, message);
        }
        /// <summary>
        /// 记录Info级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Info(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Information, message);
        }
        /// <summary>
        /// 记录Warn级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Warn(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Warning, message);
        }
        /// <summary>
        /// 记录Error级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Error(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Error, message);
        }
        /// <summary>
        /// 记录Fatal级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void Fatal(this ILogger logger, object message)
        {
            logger.Log(LogLevel.Fatal, message);
        }

        /// <summary>
        /// 记录Debug级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Debug(this ILogger logger, System.Exception exception, object message)
        {
            logger.Log(LogLevel.Debug, exception,message);
        }
        /// <summary>
        /// 记录Info级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Info(this ILogger logger, System.Exception exception, object message)
        {
            logger.Log(LogLevel.Information, exception, message);
        }
        /// <summary>
        /// 记录Warn级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Warn(this ILogger logger, System.Exception exception, object message)
        {
            logger.Log(LogLevel.Warning, exception, message);
        }
        /// <summary>
        /// 记录Error级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Error(this ILogger logger, System.Exception exception, object message)
        {
            logger.Log(LogLevel.Error, exception, message);
        }
        /// <summary>
        /// 记录Fatal级别日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Fatal(this ILogger logger, System.Exception exception, object message)
        {
            logger.Log(LogLevel.Fatal, exception, message);
        }
    }
}
