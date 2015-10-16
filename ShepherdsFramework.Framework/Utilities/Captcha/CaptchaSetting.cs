using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    public class CaptchaSetting
    {

        #region 单例模式
        /// <summary>
        /// 系统只需一个全局对象，方便复杂环境下的配置管理
        /// </summary>
        private static volatile CaptchaSetting _instance = null;
        private static readonly object lockobject = new object();


        public static CaptchaSetting Instance()
        {
            if (_instance == null)
            {
                lock (lockobject)
                {
                    if (_instance == null)
                    {
                        _instance = new CaptchaSetting();
                    }
                }
            }
            return _instance;
        }

        #endregion


        /// <summary>
        /// 是否启用验证码
        /// </summary>
        public bool EnableCaptcha { set; get; }

        private string _enableLineNoise = "";
        public bool EnableLineNoise {
            get { return _enableLineNoise.Equals("Enable", StringComparison.OrdinalIgnoreCase); }
        }

        private int _minCharacterCount = 4;
        /// <summary>
        /// 最小字符数
        /// </summary>
        public int MinCharacterCount
        {
            get { return _minCharacterCount; }
        }

        private int _maxCharacterCount = 5;
        /// <summary>
        /// 最大字符数
        /// </summary>
        public int MaxCharacterCount
        {
            get { return _maxCharacterCount; }
        }

        private CaptchaCharacterSet _captchaCharacterSet = CaptchaCharacterSet.LettersAndDigits;
        /// <summary>
        /// 字符集
        /// </summary>
        public CaptchaCharacterSet CaptchaCharacterSet
        {
            get { return _captchaCharacterSet; }
        }

        private string _captchaCookieName = "VerifySession";
        /// <summary>
        /// 验证码cookiename
        /// </summary>
        public string CaptchaCookiesName
        {
            get { return _captchaCookieName; }
        }
        /// <summary>
        /// 私有构造器
        /// </summary>
        private CaptchaSetting()
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains("Captcha:Enable"))
                _enableLineNoise = ConfigurationManager.AppSettings["Captcha:Enable"].ToString();

            if (ConfigurationManager.AppSettings.AllKeys.Contains("Captcha:CookieName"))
                _captchaCookieName = ConfigurationManager.AppSettings["Captcha:CookieName"].ToString();
          
            if (ConfigurationManager.AppSettings.AllKeys.Contains("Captcha:CharacterSet"))
                Enum.TryParse<CaptchaCharacterSet>(ConfigurationManager.AppSettings["Captcha:CharacterSet"], out _captchaCharacterSet);

            if (ConfigurationManager.AppSettings.AllKeys.Contains("Captcha:MinCharacterCount"))
                _minCharacterCount = Convert.ToInt32(ConfigurationManager.AppSettings["Captcha:MinCharacterCount"].ToString());

            if (ConfigurationManager.AppSettings.AllKeys.Contains("Captcha:MaxCharacterCount"))
                _maxCharacterCount = Convert.ToInt32(ConfigurationManager.AppSettings["Captcha:MaxCharacterCount"].ToString());
        }
    }
}
