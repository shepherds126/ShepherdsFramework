using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    /// <summary>
    /// 默认的验证码管理器
    /// </summary>
    public class DefaultCaptchaManager : ICaptchaManager
    {

        private string _captchaInputName = "CaptchaInputName";
        public MvcHtmlString GenerateCaptcha<T>(HtmlHelper<T> htmlHelper, bool isshow )
        {
            return htmlHelper.EditorForModel("DefaultCaptchaInput", new {InputName=_captchaInputName,ShowCaptchaImage=isshow});
        }

        public bool IsCaptchaValid(ActionExecutingContext actionExecutingContext)
        {
            ControllerBase controllerBase = actionExecutingContext.Controller;
            string captchaText = controllerBase.ControllerContext.HttpContext.Request.Form[_captchaInputName];
            if (string.IsNullOrEmpty(captchaText)) return false;

            string cookieName = CaptchaSetting.Instance().CaptchaCookiesName;
            HttpCookie cookie = actionExecutingContext.HttpContext.Request.Cookies[cookieName];
            string cookiesCaptcha = "";
            if (cookie != null)
            {
                if (!string.IsNullOrEmpty(cookie.Value))
                {
                    try
                    {
                        cookiesCaptcha =
                            VerificationCodeManager.GetCachedTextAndForceExpire(actionExecutingContext.HttpContext,
                                cookie.Value);
                    }
                    catch
                    {
                    }
                }
            }

            if (cookiesCaptcha == null)
                cookiesCaptcha = DateTime.UtcNow.Ticks.ToString();

            if (!string.IsNullOrEmpty(captchaText) &&
                captchaText.Equals(cookiesCaptcha, StringComparison.CurrentCultureIgnoreCase)) return true;
            return false;
        }
    }
}
