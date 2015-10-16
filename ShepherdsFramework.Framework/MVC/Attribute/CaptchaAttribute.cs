using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Framework.Utilities.Captcha;

namespace ShepherdsFramework.Framework.MVC.Attribute
{
    /// <summary>
    /// 验证码验证属性
    /// </summary>
    public class CaptchaAttribute : ActionFilterAttribute
    {
        private const string CaptchaError = "验证码不正确";

        private VerifyScenarios scenarios = VerifyScenarios.Login;

        public CaptchaAttribute(VerifyScenarios _scenarios = VerifyScenarios.Login)
        {
            scenarios = _scenarios;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (CaptchaUtility.UseCaptcha(scenarios))
            {
                ICaptchaManager captchaManager = ContainerManager.Resolve<ICaptchaManager>();
                ControllerBase controllerBase = filterContext.Controller;
                if (!captchaManager.IsCaptchaValid(filterContext))
                {
                    controllerBase.ViewData.ModelState.AddModelError("Captcha",CaptchaError);
                }else if (controllerBase.ViewData.ModelState.IsValid)
                {

                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
