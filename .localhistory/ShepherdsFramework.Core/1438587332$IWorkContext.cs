using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Domain;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// web 工作上下文
    /// </summary>
    public interface IWorkContext
    {
        Customer CurrentCustomer { get; set; }
    }
}
