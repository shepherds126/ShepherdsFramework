using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    /// <summary>
    /// 验证码存放的位置
    /// </summary>
    public enum VerificationCodePersistenceMode
    {
        /// <summary>
        /// 缓存中
        /// </summary>
        Cache,

        /// <summary>
        /// Session中
        /// </summary>
        Session
    }
    /// <summary>
    /// 验证码难易度
    /// </summary>
    public enum CaptchaDifficultLevel
    {
        /// <summary>
        /// 低
        /// </summary>
        Low = 0,
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 难
        /// </summary>
        Hard = 2
    }
    /// <summary>
    /// 验证码使用场景
    /// </summary>
    public enum VerifyScenarios
    {
        /// <summary>
        /// 登录时
        /// </summary>
        Login = 1,
        /// <summary>
        /// 找回密码时
        /// </summary>
        FindPassword = 2,
        /// <summary>
        /// 安全设置
        /// </summary>
        SecuritySetting = 3
    }
}
