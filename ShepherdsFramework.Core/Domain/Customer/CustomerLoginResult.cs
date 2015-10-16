using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Domain.Customer
{
    /// <summary>
    /// 用户登录结果
    /// </summary>
    public enum CustomerLoginResult
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 用户名或密码不正确
        /// </summary>
        UserNameOrPasswordError = 1,
        /// <summary>
        /// 未激活
        /// </summary>
        NotActivated = 2,
        /// <summary>
        /// 被封
        /// </summary>
        Banned = 3,
        /// <summary>
        /// 其他未知错误
        /// </summary>
        OtherError = 100
    }
}
