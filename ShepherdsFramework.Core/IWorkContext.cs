using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShepherdsFramework.Core.Domain.Customer;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// web 工作上下文
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// 获取当前用户
        /// </summary>
        Customer CurrentCustomer { get; set; }
        /// <summary>
        /// 是不是管理员
        /// </summary>
        bool IsAdmin { get; set; }
    }
}
