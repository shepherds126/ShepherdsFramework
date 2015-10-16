using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using ShepherdsFramework.Core.Domain.Customer;

namespace ShepherdsFramework.Service.Customers
{
    /// <summary>
    /// 身份认证业务逻辑
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {

        private Customer _customer;
        /// <summary>
        /// 身份认证登录
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="rememberPassword"></param>
        public virtual void SignIn(Customer customer, bool rememberPassword)
        {

        }
        /// <summary>
        /// 注销
        /// </summary>
        public virtual void SignOut()
        {

        }
        /// <summary>
        /// 获取当前登录的用户
        /// </summary>
        /// <returns></returns>
        public virtual Customer GetAuthenticatedCustomer()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext == null || !httpContext.Request.IsAuthenticated ||
                !(httpContext.User.Identity is FormsIdentity)) return null;
            if (_customer != null) return _customer;
            return _customer;
        }
    }
}
