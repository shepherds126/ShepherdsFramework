using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.Domain;

namespace ShepherdsFramework.Framework
{
    /// <summary>
    /// web应用程序上下文
    /// </summary>
    public partial class WebWorkContext:IWorkContext
    {
        private Customer _customer;

        public virtual  Customer CurrentCustomer
    }
}
