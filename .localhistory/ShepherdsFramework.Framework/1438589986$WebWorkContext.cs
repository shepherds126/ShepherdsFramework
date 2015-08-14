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

        private const string CustomerCookieName = "SF.customer";

        private Customer _customer;

        public virtual Customer CurrentCustomer { set;
            get
            {
                if (_customer != null)
                {
                    return _customer;
                }

                Customer customer = null;
                if (customer == null || customer.IsDelete)
                {

                }
            }
        }

        public virtual bool IsAdmin { set; get; }
    }
}
