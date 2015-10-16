using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    public static class CaptchaUtility
    {
        /// <summary>
        /// 是否使用验证码
        /// </summary>
        /// <param name="scenarios">验证码使用场景</param>
        /// <param name="isLimitCount">是否限制次数</param>
        /// <returns></returns>
        public static bool UseCaptcha(VerifyScenarios scenarios = VerifyScenarios.Login,bool isLimitCount = false)
        {
            CaptchaSetting captchaSetting = CaptchaSetting.Instance();
            if (!captchaSetting.EnableCaptcha) return false;

            return false;
        }
    }
}
