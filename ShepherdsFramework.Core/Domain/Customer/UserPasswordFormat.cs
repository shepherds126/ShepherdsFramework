using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Domain.Customer
{
    /// <summary>
    /// 用户密码存储格式
    /// </summary>
    public enum UserPasswordFormat
    {
        /// <summary>
        /// 密码未加密
        /// </summary>
        [Display(Name = "不加密")]
        Clear = 0,
        /// <summary>
        /// 标准的MD5加密
        /// </summary>
        [Display(Name = "MD5加密")]
        MD5 = 1,
    }
}
