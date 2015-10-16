using System;
using System.Web;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Framework.Utilities.Captcha;

namespace ShepherdsFramework.Framework.Handlers
{
    /// <summary>
    /// 生成验证码
    /// </summary>
    public class CaptchaHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpContextBase currentContext = new HttpContextWrapper(context);
            string cookieName = CaptchaSetting.Instance().CaptchaCookiesName;
            bool enableLineNoise = CaptchaSetting.Instance().EnableLineNoise;
            CaptchaCharacterSet characterSet = CaptchaSetting.Instance().CaptchaCharacterSet;
            int minCharacterCount = CaptchaSetting.Instance().MinCharacterCount;
            int maxCharacterCount = CaptchaSetting.Instance().MaxCharacterCount;
            string generatedKey = string.Empty;
            bool addCooikes = false;
            string key = null;
            if (context.Request.Cookies[cookieName] != null)
            {
                key = context.Request.Cookies[cookieName].Value;
            }
            System.IO.MemoryStream ms = null;
            if (!string.IsNullOrEmpty(key))
            {
                VerificationCodeManager.GetCachedTextAndForceExpire(currentContext, key);
                ms = VerificationCodeManager.GetCachedImageStream(key);
            }

            if (ms == null)
            {
                Size size = new Size(85,30);
                VerificationCodeImage image = VerificationCodeManager.GenerateAndCacheImage(currentContext, size, 300,
                    out generatedKey, characterSet, enableLineNoise, minCharacterCount, maxCharacterCount);
                ms = VerificationCodeManager.GetCachedImageStream(generatedKey);
                VerificationCodeManager.CacheText(currentContext, image.Text,generatedKey,300);
                addCooikes = true;
            }
            if (addCooikes)
            {
                HttpCookie cookie = new HttpCookie(cookieName,generatedKey);
                context.Response.Cookies.Add(cookie);
            }

            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "image/Jpeg";
            context.Response.BinaryWrite(ms.ToArray());
            context.Response.End();

        }


      
    }
}
