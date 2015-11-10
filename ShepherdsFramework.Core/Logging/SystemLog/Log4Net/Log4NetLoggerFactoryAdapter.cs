using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Core;
using ShepherdsFramework.Core.Tool;

namespace ShepherdsFramework.Core.Logging.SystemLog.Log4Net
{
    /// <summary>
    /// log4net 配置器
    /// </summary>
    public class Log4NetLoggerFactoryAdapter: ILoggerFactoryAdapter
    {

        private static bool _isconfigLoaded;


        public Log4NetLoggerFactoryAdapter() : this("~/Config/Log4net.config")
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configpath"></param>
        public Log4NetLoggerFactoryAdapter(string configpath)
        {
            if(Log4NetLoggerFactoryAdapter._isconfigLoaded)return;
            if (string.IsNullOrEmpty(configpath))
                configpath = "~/Config/Log4net.config";
            FileInfo fileInfo = new FileInfo(WebUtility.GetPhysicalFilePath(configpath));
            if(!fileInfo.Exists) throw new ApplicationException(string.Format("log4net的配置文件 {0} 没有找到",fileInfo.Name));
            XmlConfigurator.Configure(fileInfo);
            Log4NetLoggerFactoryAdapter._isconfigLoaded = true;
        }
        /// <summary>
        /// 依据loggername获取
        /// </summary>
        /// <param name="loggerName">日志名称</param>
        /// <returns></returns>
        public ILogger GetLogger(string loggerName)
        {
            return new Log4NetLogger(LogManager.GetLogger(loggerName));
        }
    }
}
