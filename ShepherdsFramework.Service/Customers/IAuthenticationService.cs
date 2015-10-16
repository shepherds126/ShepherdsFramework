using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Domain.Customer;

namespace ShepherdsFramework.Service.Customers
{
    /// <summary>
    /// 用于身份验证的接口
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="customer">当前用户</param>
        /// <param name="rememberPassword">是否机制密码</param>
        void SignIn(Customer customer, bool rememberPassword);
        /// <summary>
        /// 注销
        /// </summary>
        void SignOut();
        /// <summary>
        /// 获取当前登录的用户
        /// </summary>
        /// <returns></returns>
        Customer GetAuthenticatedCustomer();
    }
}
