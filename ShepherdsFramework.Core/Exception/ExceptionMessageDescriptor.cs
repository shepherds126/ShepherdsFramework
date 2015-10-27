using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Exception
{
    /// <summary>
    /// 异常的信息描述
    /// </summary>
    public class ExceptionMessageDescriptor
    {
        /// <summary>
        /// 格式化异常信息
        /// </summary>
        public string MessageFormat { get; set; }
        /// <summary>
        /// 格式化异常信息ResourceKey
        /// </summary>
        public string MessageFormatResourceKey { get; set; }
        /// <summary>
        /// 格式化异常信息参数
        /// </summary>
        public object[] Arguments { get; set; }

        public ExceptionMessageDescriptor()
        {
        }

        public ExceptionMessageDescriptor(string messageformatresourcekey, params object[] args)
        {
            this.MessageFormatResourceKey = messageformatresourcekey;
            this.Arguments = args;
        }
        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <returns></returns>
        internal string GetExceptionMessage()
        {
            string format = null;
            if (!string.IsNullOrEmpty(this.MessageFormatResourceKey))
            {
                format = ExceptionFormatResourceKey.GetResourceValue(this.MessageFormatResourceKey);
            }else if (!string.IsNullOrEmpty(this.MessageFormat))
            {
                format = this.MessageFormat;
            }
            if (format != null) return string.Format(format, this.Arguments);
            return string.Empty;
        }



    }
}
