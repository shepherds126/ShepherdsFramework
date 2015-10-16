using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ShepherdsFramework.Core.Tool
{
    public class StringHelper
    {
        //meta正则表达式
        private static Regex _metaregex = new Regex("<meta([^<]*)charset=([^<]*)[\"']",
            RegexOptions.IgnoreCase | RegexOptions.Multiline);

        private static Random _random = new Random();

        /// <summary>
        /// 获得字符串的长度,一个汉字的长度为1
        /// </summary>
        public static int GetStringLength(string s)
        {
            if (!string.IsNullOrEmpty(s))
                return Encoding.Default.GetBytes(s).Length;

            return 0;
        }

        /// <summary>
        /// 获得字符串中指定字符的个数
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="c">字符</param>
        /// <returns></returns>
        public static int GetCharCount(string s, char c)
        {
            if (s == null || s.Length == 0)
                return 0;
            int count = 0;
            foreach (char a in s)
            {
                if (a == c)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// 获得指定顺序的字符在字符串中的位置索引
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="order">顺序</param>
        /// <returns></returns>
        public static int IndexOf(string s, int order)
        {
            return IndexOf(s, '-', order);
        }

        /// <summary>
        /// 获得指定顺序的字符在字符串中的位置索引
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="c">字符</param>
        /// <param name="order">顺序</param>
        /// <returns></returns>
        public static int IndexOf(string s, char c, int order)
        {
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                if (c == s[i])
                {
                    if (order == 1)
                        return i;
                    order--;
                }
            }
            return -1;
        }

        #region 分割字符串

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="splitStr">分隔字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr, string splitStr)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
                return new string[0] { };

            if (sourceStr.IndexOf(splitStr) == -1)
                return new string[] { sourceStr };

            if (splitStr.Length == 1)
                return sourceStr.Split(splitStr[0]);
            else
                return Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr)
        {
            return SplitString(sourceStr, ",");
        }

        #endregion 分割字符串

        #region 截取字符串

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="startIndex">开始位置的索引</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns></returns>
        public static string SubString(string sourceStr, int startIndex, int length)
        {
            if (!string.IsNullOrEmpty(sourceStr))
            {
                if (sourceStr.Length >= (startIndex + length))
                    return sourceStr.Substring(startIndex, length);
                else
                    return sourceStr.Substring(startIndex);
            }

            return "";
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns></returns>
        public static string SubString(string sourceStr, int length)
        {
            return SubString(sourceStr, 0, length);
        }

        #endregion 截取字符串

        #region 移除前导/后导字符串

        /// <summary>
        /// 移除前导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <returns></returns>
        public static string TrimStart(string sourceStr, string trimStr)
        {
            return TrimStart(sourceStr, trimStr, true);
        }

        /// <summary>
        /// 移除前导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string TrimStart(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr) || !sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                return sourceStr;

            return sourceStr.Remove(0, trimStr.Length);
        }

        /// <summary>
        /// 移除后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <returns></returns>
        public static string TrimEnd(string sourceStr, string trimStr)
        {
            return TrimEnd(sourceStr, trimStr, true);
        }

        /// <summary>
        /// 移除后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string TrimEnd(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr) || !sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                return sourceStr;

            return sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
        }

        /// <summary>
        /// 移除前导和后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <returns></returns>
        public static string Trim(string sourceStr, string trimStr)
        {
            return Trim(sourceStr, trimStr, true);
        }

        /// <summary>
        /// 移除前导和后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string Trim(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr))
                return sourceStr;

            if (sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                sourceStr = sourceStr.Remove(0, trimStr.Length);

            if (sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                sourceStr = sourceStr.Substring(0, sourceStr.Length - trimStr.Length);

            return sourceStr;
        }

        #endregion 移除前导/后导字符串

        #region 判断字符串是否在字符串中

        public static bool IsInArray(string s, string array, string splitStr)
        {
            return IsInArray(s, SplitString(array, splitStr), false);
        }

        public static bool IsInArray(string s, string[] array, bool ignoreCase)
        {
            return GetIndexInArray(s, array, ignoreCase) > -1;
        }

        /// <summary>
        /// 判断字符串是否在字符串中
        /// </summary>
        public static bool IsInArray(string s, string array)
        {
            return IsInArray(s, StringHelper.SplitString(array, ","), false);
        }

        public static int GetIndexInArray(string s, string[] array, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(s) || array == null || array.Length == 0)
                return -1;

            int index = 0;
            string temp = null;

            if (ignoreCase)
                s = s.ToLower();

            foreach (string item in array)
            {
                if (ignoreCase)
                    temp = item.ToLower();
                else
                    temp = item;

                if (s == temp)
                    return index;
                else
                    index++;
            }

            return -1;
        }

        #endregion 判断字符串是否在字符串中

        #region 获得表单中的值

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetFormString(string key)
        {
            string value = HttpContext.Current.Request.Form[key];
            if (!string.IsNullOrWhiteSpace(value)) return value.Trim();
            else return string.Empty;
        }
        /// <summary>
        /// 获取参数的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetRequestKeyValue(string key)
        {
            string value = HttpContext.Current.Request[key];
            if (!string.IsNullOrWhiteSpace(value)) return value.Trim();
            else return string.Empty;
        }

        #endregion 获得表单中的值

        /// <summary>
        /// 获取表单所有的值
        /// </summary>
        /// <returns></returns>
        public static string GetFormAllString()
        {
            var dic = HttpContext.Current.Request.Form;
            return dic.ToStr();
        }

        #region 获得url参数的值

        /// <summary>
        /// 获得url参数的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetQueryString(string key)
        {
            string value = HttpContext.Current.Request.QueryString[key];
            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();
            else
                return string.Empty;
        }

        #endregion 获得url参数的值

        #region 获得请求的url

        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        #endregion 获得请求的url

        #region 获得上次请求的url

        public static string GetUrlReferrer()
        {
            Uri uri = HttpContext.Current.Request.UrlReferrer;
            if (uri == null)
                return string.Empty;

            return uri.ToString();
        }

        #endregion 获得上次请求的url

        #region 获得请求的主机部分

        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        #endregion 获得请求的主机部分

        /// <summary>
        /// 是否是get请求
        /// </summary>
        /// <returns></returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod == "GET";
        }

        /// <summary>
        /// 是否是post请求
        /// </summary>
        /// <returns></returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod == "POST";
        }

        /// <summary>
        /// 是否是Ajax请求
        /// </summary>
        /// <returns></returns>
        public static bool IsAjax()
        {
            return HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        /// <summary>
        ///获得邮箱提供者
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public static string GetEmailProvider(string email)
        {
            int index = email.LastIndexOf('@');
            if (index > 0)
                return email.Substring(index + 1);
            return string.Empty;
        }

        /// <summary>
        /// 创建随机值
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="onlyNumber">是否只包含数字</param>
        /// <returns>随机值</returns>
        public static string CreateRandomValue(int length, bool onlyNumber)
        {
            string randomstring = "1234567890abcdefghjkmnpqrstuvwxy";
            char[] _randomlibrary = randomstring.ToCharArray();
            int index;
            StringBuilder randomValue = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if (onlyNumber)
                    index = _random.Next(0, 10);
                else
                    index = _random.Next(0, _randomlibrary.Length);

                randomValue.Append(_randomlibrary[index]);
            }
            return randomValue.ToString();
        }

        /// <summary>
        /// 评价内容匿名类
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="onlyNumber">是否仅为数字</param>
        /// <param name="onlyName">是否仅为汉字</param>
        /// <param name="onlyZiMu">是否仅为字母</param>
        /// <returns></returns>
        public static string CreateAnonymityValue(int length, bool onlyNumber, bool onlyName, bool onlyZiMu)
        {
            const string nameStr =
                "亚 秋 品  笑 玉 衡 逍 龙 点 明 月 紫 棋 光 勇 飞 星 阳 风 歌 千 元 大 未 青 乐 伦 春 秋 夏 冬 陌 清 风 雨 君 忆 天 白 黑 唯 清 深 林 故 微 凉 如 梦 轻 烟 蓦 然 流 年  度 山 歡 颜 言 花 暖 思 念 歌 城 北 海  梦 素  景 欢 温 半 颜 画  风 月 理 想 良 靓  笑 墨 雪 舞 琴 朝 暮 雪 希 锦 珠 南 以 云 森 伊 白 珊 童 鹿 萌 兔 嗨 梓 朴 灿 芭 包 海 别 致 西 米 新 拉 橘 小 丸  左 麦 芽 糖 艾 逗 比 东 南 西 安 丁 一 可 唯 梅 飞 叶 晴 杰 虹 米 朵 琳 静 亮 强 美 乔 细 天 依 大 玉 初 平 蓝 灵 晨 童 包 洋 金 凉 凡 宇 开 精 郑 毅 力 宝 贝 赛 艺 世 最 我 琦 宁 杜 飘 用 曾 莎 刘 媚 浅 完 健 戴 康 纷 高 顺 代 提 迎 等 门 奇 淘 桃 王 志 智 慧 少 格 妮 妃 拉 方 吴 俊 周 英 雄 阳 沈 森 林 蝶 胡 真 珍 冰 背 蜜 峰 蜂 潘 不 清 青 表 杨 朱 泉 文 楚 学 单 左 菲 若 奇 其 右 正 工 好 梦 尚 京  虎 哈 喻 力 中 央 古 百 全 书 琴  科 嘉 莫 熊 腾 达 石 易 群 郡 珍 凤 峻 仪 育 萍 承 堂 常 丹 华 彻 澈 昌 日  恒 黎 尚 鹏 谢 许 燕 马 巴 珠 荣 启 默 云 阑 兰 莲 连 鲁 伦 葵 是 优 良 霖 俐 哲 田 蔡 澜 方 银";
            const string zimuStr = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
            const string shuziStr = "0 1 2 3 4 5 6 7 8 9";
            char[] namelib = nameStr.Replace(" ", "").ToCharArray();
            char[] shuzilib = shuziStr.Replace(" ", "").ToCharArray();
            char[] zimulib = zimuStr.Replace(" ", "").ToCharArray();

            var randomValue = new StringBuilder();
            var tempValue = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                //纯数字
                if (onlyNumber && !onlyName && !onlyZiMu)
                {
                    int shuziIndex = _random.Next(0, shuzilib.Count());
                    randomValue.Append(shuzilib[shuziIndex]);
                }
                //纯汉字
                else if (!onlyNumber && onlyName && !onlyZiMu)
                {
                    int nameIndex = _random.Next(0, namelib.Count());
                    randomValue.Append(namelib[nameIndex]);
                }
                //纯字母
                else if (!onlyNumber && !onlyName && onlyZiMu)
                {
                    int zimuIndex = _random.Next(0, zimulib.Count());
                    randomValue.Append(zimulib[zimuIndex]);
                }
                else
                {
                    int shuziIndex = _random.Next(0, shuzilib.Count());
                    int nameIndex = _random.Next(0, namelib.Count());
                    int zimuIndex = _random.Next(0, zimulib.Count());
                    tempValue.Append(zimulib[zimuIndex]);
                    tempValue.Append(namelib[nameIndex]);
                    tempValue.Append(shuzilib[shuziIndex]);
                    var random = _random.Next(0, 3);
                    var temp = tempValue[random];
                    if (randomValue.Length == length - 1)
                    {
                        var re = new Regex("[\u4e00-\u9fa5]");
                        //如果第一位是字母或者数字的话,末位不应该为汉字
                        if (re.IsMatch(temp.ToStr()) && !re.IsMatch(randomValue[0].ToStr()))
                        {
                            temp = zimulib[zimuIndex];
                        }
                    }
                    tempValue.Clear();
                    randomValue.Append(temp);
                }
            }
            var resultName = HideUsername(randomValue.ToStr(), 3);
            return resultName;
        }
        /// <summary>
        /// 获取随机时间
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DateTime RandomDate(DateTime beginDate, DateTime endDate)
        {
            var minTime = new DateTime();
            var maxTime = new DateTime();
            var ts = new TimeSpan(endDate.Ticks - beginDate.Ticks);

            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > Int32.MaxValue)
            {
                iTotalSecontds = Int32.MaxValue;
            }
            else if (dTotalSecontds < Int32.MinValue)
            {
                iTotalSecontds = Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = beginDate;
                maxTime = endDate;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = endDate;
                maxTime = beginDate;
            }
            else
            {
                return endDate;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue;

            int i = _random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomNum(int maxValue)
        {
            return _random.Next(0, maxValue);
        }
        /// <summary>
        ///  获取随机数
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int GetRandomNum(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
        

        /// <summary>
        /// 获得参数列表
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static NameValueCollection GetParmList(string data)
        {
            NameValueCollection parmList = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(data))
            {
                int length = data.Length;
                for (int i = 0; i < length; i++)
                {
                    int startIndex = i;
                    int endIndex = -1;
                    while (i < length)
                    {
                        char c = data[i];
                        if (c == '=')
                        {
                            if (endIndex < 0)
                                endIndex = i;
                        }
                        else if (c == '&')
                        {
                            break;
                        }
                        i++;
                    }
                    string key;
                    string value;
                    if (endIndex >= 0)
                    {
                        key = data.Substring(startIndex, endIndex - startIndex);
                        value = data.Substring(endIndex + 1, (i - endIndex) - 1);
                    }
                    else
                    {
                        key = data.Substring(startIndex, i - startIndex);
                        value = string.Empty;
                    }
                    parmList[key] = value;
                    if ((i == (length - 1)) && (data[i] == '&'))
                        parmList[key] = string.Empty;
                }
            }
            return parmList;
        }


        public static string Getstring(NameValueCollection collections)
        {
            string param = "";
            if (collections.Count > 0)
            {
                foreach (var key in collections.AllKeys)
                {
                    param += string.Format("{0}={1}{2}", key, collections[key], "&");
                }
                param = param.Substring(0, param.Length - 1);
            }
            return param;
        }

        /// <summary>
        /// 隐藏邮箱
        /// </summary>
        public static string HideEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "";
            int index = email.LastIndexOf('@');

            if (index == 1)
                return "*" + email.Substring(index);
            if (index == 2)
                return email[0] + "*" + email.Substring(index);

            StringBuilder sb = new StringBuilder();
            sb.Append(email.Substring(0, 2));
            int count = index - 2;
            while (count > 0)
            {
                sb.Append("*");
                count--;
            }
            sb.Append(email.Substring(index));
            return sb.ToString();
        }

        /// <summary>
        /// 隐藏手机
        /// </summary>
        public static string HideMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile)) return "";
            return mobile.Substring(0, 3) + "****" + mobile.Substring(7);
        }

        /// <summary>
        /// 隐藏用户名
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string HideUsername(string username)
        {
            if (username.Length == 0) return "";
            int count = username.Length;
            StringBuilder sb = new StringBuilder();
            sb.Append(username.Substring(0, 1));
            int index = username.Length - 2;
            while (index > 0)
            {
                sb.Append("*");
                index--;
            }
            sb.Append(username.Substring(username.Length - 1));
            return sb.ToString();
        }
        /// <summary>
        /// 隐藏用户名
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="hideNum">隐藏星号个数</param>
        /// <returns></returns>
        public static string HideUsername(string username, int hideNum)
        {
            if (username.Length == 0) return "";
            var sb = new StringBuilder();
            sb.Append(username.Substring(0, 1));
            while (hideNum > 0)
            {
                sb.Append("*");
                hideNum--;
            }
            sb.Append(username.Substring(username.Length - 1));
            return sb.ToString();
        }

        #region 判断IP地址是否为内网IP地址

        /// <summary>
        /// 判断IP地址是否为内网IP地址
        /// </summary>
        /// <param name="ipAddress">IP地址字符串</param>
        /// <returns></returns>
        public static bool IsInnerIP(String ipAddress)
        {
            if (ipAddress == "::1") ipAddress = "127.0.0.1";
            bool isInnerIp = false;
            long ipNum = GetIpNum(ipAddress);
            /**
               私有IP：A类  10.0.0.0-10.255.255.255
                       B类  172.16.0.0-172.31.255.255
                       C类  192.168.0.0-192.168.255.255
                       当然，还有127这个网段是环回地址
              **/
            long aBegin = GetIpNum("10.0.0.0");
            long aEnd = GetIpNum("10.255.255.255");
            long bBegin = GetIpNum("172.16.0.0");
            long bEnd = GetIpNum("172.31.255.255");
            long cBegin = GetIpNum("192.168.0.0");
            long cEnd = GetIpNum("192.168.255.255");
            isInnerIp = IsInner(ipNum, aBegin, aEnd) || IsInner(ipNum, bBegin, bEnd) || IsInner(ipNum, cBegin, cEnd) ||
                        ipAddress.Equals("127.0.0.1");
            return isInnerIp;
        }

        /// <summary>
        /// 把IP地址转换为Long型数字
        /// </summary>
        /// <param name="ipAddress">IP地址字符串</param>
        /// <returns></returns>
        private static long GetIpNum(String ipAddress)
        {
            String[] ip = ipAddress.Split('.');
            long a = int.Parse(ip[0]);
            long b = int.Parse(ip[1]);
            long c = int.Parse(ip[2]);
            long d = int.Parse(ip[3]);

            long ipNum = a * 256 * 256 * 256 + b * 256 * 256 + c * 256 + d;
            return ipNum;
        }

        /// <summary>
        /// 判断用户IP地址转换为Long型后是否在内网IP地址所在范围
        /// </summary>
        /// <param name="userIp"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static bool IsInner(long userIp, long begin, long end)
        {
            return (userIp >= begin) && (userIp <= end);
        }

        #endregion 判断IP地址是否为内网IP地址

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(string value)
        {
            return Regex.IsMatch(value, @"^\d*$");
        }

        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^-?\d+\.\d+$");
        }

        #region 是否含有中文 hewencong

        /// <summary>
        /// 是否含有中文 hewencong
        /// </summary>
        /// <param name="value">待检测字符串</param>
        /// <returns></returns>
        public static bool IsHasChinese(string value)
        {
            return Regex.IsMatch(value, "[\u4e00-\u9fa5a-zA-Z ]");
        }

        #endregion

        #region 计算字符串长度 hewencong

        /// <summary>
        /// 计算字符串长度 hewencong
        /// 一个汉字 2字符，
        /// 一个字符 1字符
        /// </summary>
        /// <param name="sValue">待计算的字符串</param>
        /// <returns>返回计算长度</returns>
        public static int CalcuChineseLen(string sValue)
        {
            if (string.IsNullOrWhiteSpace(sValue))
            {
                return 0;
            }
            int len = 0;
            foreach (var item in sValue)
            {
                if (IsHasChinese(item.ToString()))
                {
                    len = len + 2;
                }
                else
                {
                    len++;
                }
            }
            return len;
        }

        #endregion

        #region 判断是否为手机号码 hewencong

        /// <summary>
        /// 判断是否为手机号码 hewencong
        /// </summary>
        /// <param name="sPhoneNumber">待验证手机号码</param>
        /// <returns></returns>
        public static bool IsMobilePhoneNumber(string sPhoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(sPhoneNumber, @"^[1]+[3,5,7,8]+\d{9}$");
        }

        #endregion

        #region 验证是否为电话号码

        /// <summary>
        /// 验证是否为电话号码 hewencong
        /// </summary>
        /// <param name="sPhoneNumber">待验证的电话号码</param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string sPhoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(sPhoneNumber, @"^(\d{3,4}-)?\d{6,8}$");
        }

        #endregion

        /// <summary>
        /// 指定显示的字符串长度
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="i">显示的长度</param>
        /// <returns></returns>
        public static string GetAppointStrLength(string source, int i)
        {
            if (source.IsNullOrEmpty())
            {
                return string.Empty;
            }
            var len = GetStringLength(source);
            if (len <= i)
            {
                return source;
            }
            if (i > 20)
            {
                i = len;
            }
            var result = SubString(source, 0, i);
            return result + "...";
        }


        /// <summary>
        /// 检测是不是移动客户端
        /// 参考：http://www.mikel.cn/%E5%BC%80%E5%8F%91%E7%AC%94%E8%AE%B0/%E8%BD%AC%E8%BD%BD%E5%88%A4%E6%96%AD%E7%A7%BB%E5%8A%A8%E5%AE%A2%E6%88%B7%E7%AB%AF%E8%AE%BE%E5%A4%87-alronzhang-%E5%8D%9A%E5%AE%A2%E5%9B%AD.html
        /// </summary>
        /// <returns>如果是移动客户端,返回true,否则,返回false</returns>
        public static bool IsMobileBrowser()
        {

            //GETS THE CURRENT USER CONTEXT

            HttpContext context = HttpContext.Current;



            //FIRST TRY BUILT IN ASP.NT CHECK

            if (context.Request.Browser.IsMobileDevice)
            {

                return true;

            }

            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER

            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {

                return true;

            }

            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP

            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
            context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {

                return true;

            }

            //AND FINALLY CHECK THE HTTP_USER_AGENT

            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING

            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types

                string[] mobiles =

                    new[]

                    {

                        //"midp", "j2me", "avant", "docomo",

                        //"novarra", "palmos", "palmsource",

                        //"240x320", "opwv", "chtml",

                        //"pda", "windows ce", "mmp/",

                        //"blackberry", "mib/", "symbian",

                        //"wireless", "nokia", "hand", "mobi",
                        //"phone", "cdm", "up.b", "audio",

                        //"SIE-", "SEC-", "samsung", "HTC",

                        //"mot-", "mitsu", "sagem", "sony"

                        //, "alcatel", "lg", "eric", "vx",

                        //"NEC", "philips", "mmm", "xx",

                        //"panasonic", "sharp", "wap", "sch",

                        //"rover", "pocket", "benq", "java",

                        //"pt", "pg", "vox", "amoi",

                        //"bird", "compal", "kg", "voda",

                        //"sany", "kdd", "dbt", "sendo",

                        //"sgh", "gradi", "jb", "dddi",

                        //"moto", "iphone",
                        "UnityPlayer",
                        "CFNetwork",
                        "Android",
                        "iPad",
                        "iPhone","CasamiaBrowser"

                    };
                //Loop through each item in the list created above

                //and check if the header contains that text

                foreach (string s in mobiles)
                {

                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].

                        ToLower().Contains(s.ToLower()))
                    {

                        return true;

                    }

                }

            }
            return false;

        }

    }
}
