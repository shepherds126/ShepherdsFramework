using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ShepherdsFramework.Core.Logging.SystemLog.Log4Net
{
    /// <summary>
    /// Log4Net实现ILogger
    /// </summary>
   public class Log4NetLogger:ILogger
    {
        private ILog _logger;

        public Log4NetLogger(ILog logger)
        {
            this._logger = logger;
        }
        /// <summary>
        /// 检查level级别的日志是否启用
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnable(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return this._logger.IsDebugEnabled;
                case LogLevel.Information:
                    return this._logger.IsInfoEnabled;
                case LogLevel.Error:
                    return this._logger.IsErrorEnabled;
                case LogLevel.Fatal:
                    return this._logger.IsInfoEnabled;
                case LogLevel.Warning:
                    return this._logger.IsDebugEnabled;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 记录level级别日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void Log(LogLevel level, object message)
        {
            if(!IsEnable(level)) return;
            switch (level)
            {
                case LogLevel.Debug:
                    this._logger.Debug(message);
                    break;
                case LogLevel.Information:
                    this._logger.Info(message);
                    break;
                case LogLevel.Error:
                    this._logger.Error(message);
                    break;
                case LogLevel.Fatal:
                    this._logger.Fatal(message);
                    break;
                case LogLevel.Warning:
                    this._logger.Warn(message);
                    break;
            }

        }
        /// <summary>
        /// 记录level级别日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public void Log(LogLevel level, System.Exception exception, object message)
        {
            if (!IsEnable(level)) return;
            switch (level)
            {
                case LogLevel.Debug:
                    this._logger.Debug(message,exception);
                    break;
                case LogLevel.Information:
                    this._logger.Info(message,exception);
                    break;
                case LogLevel.Error:
                    this._logger.Error(message,exception);
                    break;
                case LogLevel.Fatal:
                    this._logger.Fatal(message,exception);
                    break;
                case LogLevel.Warning:
                    this._logger.Warn(message,exception);
                    break;
            }
        }
    }
}
