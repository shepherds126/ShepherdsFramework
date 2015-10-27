using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ShepherdsFramework.Core.Logging;

namespace ShepherdsFramework.Core.Exception
{
    /// <summary>
    /// 异常描述
    /// </summary>
    public abstract class ExceptionDescriptor
    {
        /// <summary>
        /// 是否计入系统日志
        /// </summary>
        public bool IsLogEnabled { get; protected set; }
        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevel LogLevel { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 异常信息描述
        /// </summary>
        public ExceptionMessageDescriptor MessageDescriptor { get; set; }

        public abstract string GetLoggingMessage();

        /// <summary>
        /// 获取友好的异常提醒
        /// </summary>
        /// <returns></returns>
        public virtual string GetFriendlyMessage()
        {
            if (!string.IsNullOrEmpty(this.Message)) return this.Message;
            if (this.MessageDescriptor != null) return this.MessageDescriptor.GetExceptionMessage();
            return null;
        }
        /// <summary>
        /// 获取异常的操作上下文信息
        /// </summary>
        /// <returns></returns>
        public virtual string GetOperationContextMessage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            HttpContext context = HttpContext.Current;
            if (context != null && context.Request != null)
            {
                if (context.Request.Url != null)
                    stringBuilder.AppendLine(string.Format(ExceptionFormatResourceKey.GetResourceValue("Exception_Url"), context.Request.Url.AbsoluteUri));
                if (context.Request.RequestType != null)
                    stringBuilder.AppendLine(string.Format(ExceptionFormatResourceKey.GetResourceValue("Exception_HttpMethod"),context.Request.RequestType));
                if (context.Request.UserHostAddress != null)
                    stringBuilder.AppendLine(string.Format(ExceptionFormatResourceKey.GetResourceValue("Exception_UserIP"),context.Request.UserHostAddress));
                if (context.Request.UserAgent != null)
                    stringBuilder.AppendLine(string.Format(ExceptionFormatResourceKey.GetResourceValue("Exception_UserAgent"), context.Request.UserAgent));

            }
            return stringBuilder.ToString();
        }
       
    }
}
