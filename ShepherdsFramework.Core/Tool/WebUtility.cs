using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// web 请求的工具类
    /// </summary>
    public static class WebUtility
    {
        public static readonly string HtmlNewLine = "<br />";

        /// <summary>
        /// 将URL转换为在请求客户端可用的 URL（转换 ~/ 为绝对路径）
        /// 
        /// </summary>
        /// <param name="relativeUrl">相对url</param>
        /// <returns>
        /// 返回绝对路径
        /// </returns>
        public static string ResolveUrl(string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl) || !relativeUrl.StartsWith("~/"))
                return relativeUrl;
            string[] strArray = relativeUrl.Split('?');
            string str = VirtualPathUtility.ToAbsolute(strArray[0]);
            if (strArray.Length > 1)
                str = str + "?" + strArray[1];
            return str;
        }

        /// <summary>
        /// 获取带传输协议的完整的主机地址
        /// 
        /// </summary>
        /// <param name="uri">Uri</param>
        /// <returns>
        /// 
        /// <para>
        /// 返回带传输协议的完整的主机地址
        /// </para>
        /// 
        /// <example>
        /// https://www.spacebuilder.cn:8080
        /// </example>
        /// 
        /// </returns>
        public static string HostPath(Uri uri)
        {
            if (uri == null)
                return string.Empty;
            string str = uri.IsDefaultPort ? string.Empty : ":" + Convert.ToString(uri.Port, (IFormatProvider)CultureInfo.InvariantCulture);
            return uri.Scheme + Uri.SchemeDelimiter + uri.Host + str;
        }

        /// <summary>
        /// 获取物理文件路径
        /// 
        /// </summary>
        /// <param name="filePath">
        /// <remarks>
        /// 
        /// <para>
        /// filePath支持以下格式：
        /// </para>
        /// 
        /// <list type="bullet">
        /// 
        /// <item>
        /// ~/abc/
        /// </item>
        /// 
        /// <item>
        /// c:\abc\
        /// </item>
        /// 
        /// <item>
        /// \\192.168.0.1\abc\
        /// </item>
        /// 
        /// </list>
        /// 
        /// </remarks>
        /// </param>
        /// <returns/>
        public static string GetPhysicalFilePath(string filePath)
        {
            string str;
            if (filePath.IndexOf(":\\") != -1 || filePath.IndexOf("\\\\") != -1)
                str = filePath;
            else if (HostingEnvironment.IsHosted)
            {
                str = HostingEnvironment.MapPath(filePath);
            }
            else
            {
                filePath = filePath.Replace('/', Path.DirectorySeparatorChar).Replace("~", "");
                str = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }
            return str;
        }

        /// <summary>
        /// 把content中的虚拟路径转化成完整的url
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 例如： /abc/e.aspx 转化成 http://www.spacebuilder.cn/abc/e.aspx
        /// 
        /// </remarks>
        /// <param name="content">content</param>
        public static string FormatCompleteUrl(string content)
        {
            string pattern1 = "src=[\"']\\s*(/[^\"']*)\\s*[\"']";
            string pattern2 = "href=[\"']\\s*(/[^\"']*)\\s*[\"']";
            string str = WebUtility.HostPath(HttpContext.Current.Request.Url);
            content = Regex.Replace(content, pattern1, "src=\"" + str + "$1\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            content = Regex.Replace(content, pattern2, "href=\"" + str + "$1\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return content;
        }

        /// <summary>
        /// 获取根域名
        /// 
        /// </summary>
        /// <param name="uri">uri</param><param name="domainRules">域名规则</param>
        public static string GetServerDomain(Uri uri, string[] domainRules)
        {
            if (uri == (Uri)null)
                return string.Empty;
            string str1 = uri.Host.ToString().ToLower();
            if (str1.IndexOf('.') <= 0)
                return str1;
            string[] strArray1 = str1.Split('.');
            string s = strArray1.GetValue(strArray1.Length - 1).ToString();
            int result = -1;
            if (int.TryParse(s, out result))
                return str1;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            for (int index = 0; index < domainRules.Length; ++index)
            {
                if (str1.EndsWith(domainRules[index].ToLower()))
                {
                    string oldValue = domainRules[index].ToLower();
                    string str5 = str1.Replace(oldValue, "");
                    if (str5.IndexOf('.') <= 0)
                        return str5 + oldValue;
                    string[] strArray2 = str5.Split('.');
                    return strArray2.GetValue(strArray2.Length - 1).ToString() + oldValue;
                }
                str4 = str1;
            }
            return str4;
        }

        /// <summary>
        /// html编码
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// 调用HttpUtility.HtmlEncode()，当前已知仅作如下转换：
        /// </para>
        /// 
        /// <list type="bullet">
        /// 
        /// <item>
        /// &lt; = &amp;lt;
        /// </item>
        /// 
        /// <item>
        /// &gt; = &amp;gt;
        /// </item>
        /// 
        /// <item>
        /// &amp; = &amp;amp;
        /// </item>
        /// 
        /// <item>
        /// " = &amp;quot;
        /// </item>
        /// 
        /// </list>
        /// 
        /// </remarks>
        /// <param name="rawContent">待编码的字符串</param>
        public static string HtmlEncode(string rawContent)
        {
            if (string.IsNullOrEmpty(rawContent))
                return rawContent;
            return HttpUtility.HtmlEncode(rawContent);
        }

        /// <summary>
        /// html解码
        /// 
        /// </summary>
        /// <param name="rawContent">待解码的字符串</param>
        /// <returns>
        /// 解码后的字符串
        /// </returns>
        public static string HtmlDecode(string rawContent)
        {
            if (string.IsNullOrEmpty(rawContent))
                return rawContent;
            return HttpUtility.HtmlDecode(rawContent);
        }

        /// <summary>
        /// Url编码
        /// 
        /// </summary>
        /// <param name="urlToEncode">待编码的url字符串</param>
        /// <returns>
        /// 编码后的url字符串
        /// </returns>
        public static string UrlEncode(string urlToEncode)
        {
            if (string.IsNullOrEmpty(urlToEncode))
                return urlToEncode;
            return HttpUtility.UrlEncode(urlToEncode).Replace("'", "%27");
        }

        /// <summary>
        /// Url解码
        /// 
        /// </summary>
        /// <param name="urlToDecode">待解码的字符串</param>
        /// <returns>
        /// 解码后的字符串
        /// </returns>
        public static string UrlDecode(string urlToDecode)
        {
            if (string.IsNullOrEmpty(urlToDecode))
                return urlToDecode;
            return HttpUtility.UrlDecode(urlToDecode);
        }

        /// <summary>
        /// 获取IP地址
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// 返回获取的ip地址
        /// </returns>
        public static string GetIP()
        {
            return WebUtility.GetIP(HttpContext.Current);
        }

        /// <summary>
        /// 透过代理获取真实IP
        /// 
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <returns>
        /// 返回获取的ip地址
        /// </returns>
        public static string GetIP(HttpContext httpContext)
        {
            string str1 = string.Empty;
            if (httpContext == null)
                return str1;
            string str2 = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(str2))
                str2 = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(str2))
                str2 = HttpContext.Current.Request.UserHostAddress;
            return str2;
        }

        /// <summary>
        /// 返回 StatusCode 404
        /// 
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        public static void Return404(HttpContext httpContext)
        {
            WebUtility.ReturnStatusCode(httpContext, 404, (string)null, false);
            if (httpContext == null)
                return;
            httpContext.Response.SuppressContent = true;
            httpContext.Response.End();
        }

        /// <summary>
        /// 返回 StatusCode 403
        /// 
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        public static void Return403(HttpContext httpContext)
        {
            WebUtility.ReturnStatusCode(httpContext, 403, (string)null, false);
            if (httpContext == null)
                return;
            httpContext.Response.SuppressContent = true;
            httpContext.Response.End();
        }

        /// <summary>
        /// 返回 StatusCode 304
        /// 
        /// </summary>
        /// <param name="httpContext">HttpContext</param><param name="endResponse">是否终止HttpResponse</param>
        public static void Return304(HttpContext httpContext, bool endResponse = true)
        {
            WebUtility.ReturnStatusCode(httpContext, 304, "304 Not Modified", endResponse);
        }

        /// <summary>
        /// 返回http状态码
        /// 
        /// </summary>
        /// <param name="httpContext">HttpContext</param><param name="statusCode">状态码</param><param name="status">状态描述字符串</param><param name="endResponse">是否终止HttpResponse</param>
        private static void ReturnStatusCode(HttpContext httpContext, int statusCode, string status, bool endResponse)
        {
            if (httpContext == null)
                return;
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            if (!string.IsNullOrEmpty(status))
                httpContext.Response.Status = status;
            if (!endResponse)
                return;
            httpContext.Response.End();
        }

        /// <summary>
        /// 设置当前响应的状态码为指定值
        /// 
        /// </summary>
        /// <param name="response">当前响应</param>
        public static void SetStatusCodeForError(HttpResponseBase response)
        {
            response.StatusCode = 300;
        }
    }
}
