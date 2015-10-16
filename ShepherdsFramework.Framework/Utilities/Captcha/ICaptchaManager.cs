using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    /// <summary>
    /// 验证码管理器接口
    /// </summary>
    public interface ICaptchaManager
    {
        /// <summary>
        /// 生成验证码(支持强类型视图的captcha控件)
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="isshowCaptchaImage"></param>
        /// <returns></returns>
        MvcHtmlString GenerateCaptcha<T>(HtmlHelper<T> htmlHelper, bool isshowCaptchaImage = false);
        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="actionExecuting"></param>
        /// <returns></returns>
        bool IsCaptchaValid(ActionExecutingContext actionExecuting);
    }
}
