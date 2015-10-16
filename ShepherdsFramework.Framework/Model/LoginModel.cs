using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Framework.Model
{
    /// <summary>
    /// 登录ViewModel
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 回跳的网页
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name="密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "请输入有效的手机号或邮箱")]
        public string UserName { get; set; }
        /// <summary>
        /// 是否记住密码
        /// </summary>
        [Display(Name = "十天免登陆")]
        public bool RememberPassword { get; set; }
    }
}
