using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Framework.Utilities.Captcha;

namespace ShepherdsFramework.Framework.MVC.Html
{
    public static class HtmlHelperCaptchaExtensions
    {
        public static MvcHtmlString Captcha<T>(this HtmlHelper<T> htmlHelper,VerifyScenarios scenarios = VerifyScenarios.Login,bool showCaptchaImage = false,string templateName = "Captcha" )
        {
            ICaptchaManager captchaManager = ContainerManager.Resolve<ICaptchaManager>();
            MvcHtmlString captchaText = captchaManager.GenerateCaptcha(htmlHelper, showCaptchaImage);
            return htmlHelper.EditorForModel(templateName, new {CaptchaText = captchaText});
        }
    }
}
