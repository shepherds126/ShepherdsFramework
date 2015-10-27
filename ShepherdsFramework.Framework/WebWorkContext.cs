using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Core.Domain.Customer;
using ShepherdsFramework.Service.Customers;

namespace ShepherdsFramework.Framework
{
    /// <summary>
    /// web应用程序上下文
    /// </summary>
    public partial class WebWorkContext:IWorkContext
    {

        private const string CustomerCookieName = "SF.customer";

        private Customer _customer;

        private readonly ICustomersService _customersService;
        private readonly IAuthenticationService _authenticationService;

        public WebWorkContext(ICustomersService customersService,IAuthenticationService authenticationService)
        {
            this._customersService = customersService;
            this._authenticationService = authenticationService;
        }


        public virtual Customer CurrentCustomer { 
            get
            {
                if (_customer != null)
                {
                    return _customer;
                }
                
                
                IAuthenticationService authenticationService = ContainerManager.Resolve<IAuthenticationService>();
                Customer customer = authenticationService.GetAuthenticatedCustomer();
                if (customer == null || customer.IsDelete)
                {

                }

                if (!customer.IsDelete)
                {
                    _customer = customer;
                }
                return _customer;
            }
            set { _customer = value; }
        }

        public virtual bool IsAdmin { set; get; }
    }
}
