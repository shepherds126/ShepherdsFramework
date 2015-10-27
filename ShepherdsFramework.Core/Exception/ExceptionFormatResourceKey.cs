using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Exception
{
    /// <summary>
    /// 异常信息格式化Key
    /// </summary>
    public class ExceptionFormatResourceKey
    {

        private static Dictionary<string, string> Dictionary = InitalizeExceptionResourceKey();

        private static Dictionary<string, string> InitalizeExceptionResourceKey()
        {
            Dictionary<string,string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Exception_AccessDenied", "没有足够的访问权限");
            dictionary.Add("Exception_NotFound", "\"{0}\"不存在或已删除,Id:{1}");
            dictionary.Add("Exception_RegisterDenied", "禁止注册");
            dictionary.Add("Exception_UserNotFound", "用户\"{0}\"不存在或已删除");
            dictionary.Add("Exception_UnknownError", "未知错误");
            dictionary.Add("Exception_EmailUnableToSend", "发送邮件时产生异常{0}");
            dictionary.Add("Exception_SMSUnableToSend", "发送短信时产生异常{0}");
            dictionary.Add("Exception_Url", "异常的URL:{0}");
            dictionary.Add("Exception_HttpMethod", "请求方法类型:{0}");
            dictionary.Add("Exception_UserIP", "用户的IP:{0}");
            dictionary.Add("Exception_UserAgent", "UserAgent:{0}");
            return dictionary;
        }
        /// <summary>
        /// 获取异常资源信息的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetResourceValue(string key)
        {
            if (string.IsNullOrEmpty(key)) return "";
            return Dictionary[key];
        }
    }
}
