using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Exception
{
    /// <summary>
    /// 异常的外观模式
    /// </summary>
    public class ExceptionFacade : System.Exception
    {
        private readonly ExceptionDescriptor exceptionDescriptor;

        /// <summary>
        /// 异常显示
        /// </summary>
        public override string Message {
            get
            {
                if (this.exceptionDescriptor != null) return this.exceptionDescriptor.GetFriendlyMessage();
                return base.Message;
            }
        }
        /// <summary>
        /// 操作的上下文信息
        /// </summary>
        public string OperationContextMessage
        {
            get { return this.exceptionDescriptor.GetOperationContextMessage(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_exceptionDescriptor"></param>
        /// <param name="innerException"></param>
        public ExceptionFacade(ExceptionDescriptor _exceptionDescriptor, System.Exception innerException = null):base(null,innerException)
        {
            this.exceptionDescriptor = _exceptionDescriptor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_exceptionDescriptor"></param>
        /// <param name="message"></param>
        public ExceptionFacade(string message,System.Exception innerException) : base(message,innerException)
        {
            this.exceptionDescriptor = new CommonExceptionDescriptor(message);
        }
    }
}
