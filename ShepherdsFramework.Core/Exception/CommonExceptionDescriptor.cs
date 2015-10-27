using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Logging;

namespace ShepherdsFramework.Core.Exception
{
    /// <summary>
    /// 通用异常描述
    /// </summary>
    public class CommonExceptionDescriptor:ExceptionDescriptor
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="message">异常信息</param>
        public CommonExceptionDescriptor(string message)
        {
            this.Message = message;
            this.IsLogEnabled = true;
            this.LogLevel = LogLevel.Warning;
        }

        public CommonExceptionDescriptor() : this("")
        {
        }

        public CommonExceptionDescriptor(string messageformat, params object[] args)
            : this(string.Format(messageformat, args))
        {
        }
        /// <summary>
        /// 日志信息
        /// </summary>
        /// <returns></returns>
        public override string GetLoggingMessage()
        {
            return this.GetFriendlyMessage() + "--" + this.GetOperationContextMessage();
        }

        /// <summary>
        /// 禁止注册
        /// </summary>
        /// <returns></returns>
        public CommonExceptionDescriptor RegisterDenieDescriptor()
        {
            this.MessageDescriptor = new ExceptionMessageDescriptor("Exception_RegisterDenied");
            return this;
        }

        public CommonExceptionDescriptor EmailToSenDescriptor(string message)
        {
            this.MessageDescriptor = new ExceptionMessageDescriptor("Exception_EmailUnableToSend",message);
            return this;
        }
    }
}
