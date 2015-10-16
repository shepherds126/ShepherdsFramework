using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// 类型转换辅助类
    /// </summary>
    public static class ConvertHelper
    {

        #region 判断浮点数相等
        /// <summary>
        /// 判断浮点数相等
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        public static bool FloatEqualTo(this decimal numberA, decimal numberB)
        {
            if (Math.Abs(numberA - numberB).CompareTo(0.0001.ToDecimal()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool FloatEqualTo(this float numberA, float numberB)
        {
            if (Math.Abs(numberA - numberB).CompareTo(0.0001.ToDecimal()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool FloatEqualTo(this double numberA, double numberB)
        {
            if (Math.Abs(numberA - numberB).CompareTo(0.0001.ToDecimal()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断对象是否为空
        #region (Object类型)判断对象是否为空，为空返回true
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public static bool IsNullOrEmpty(this object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        #endregion
        #region (泛型)判断对象是否为空，为空返回true
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <typeparam name="T">要验证的对象的类型</typeparam>
        /// <param name="data">要验证的对象</param>        
        public static bool IsNullOrEmpty<T>(this T data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        #endregion
        #endregion

        #region 类型转化
        /// <summary>
        /// Object转化为Int32类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return 0;
            else
                return Convert.ToInt32(obj);
        }
        /// <summary>
        /// Object转化为DateTime类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return DateTime.MinValue;
            else
                return Convert.ToDateTime(obj);
        }
        /// <summary>
        /// Object转化为单精度浮点类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToFloat(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return 0;
            else
                return Convert.ToSingle(obj);

        }
        /// <summary>
        /// Object转化为双精度浮点类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDouble(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return 0;
            else
                return Convert.ToDouble(obj);
        }
        /// <summary>
        /// Object转化为Bool类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Boolean ToBoolean(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return false;
            else
                return Convert.ToBoolean(obj);

        }
        /// <summary>
        /// Object转化为String类型（强制转化,如果为空则返回Empty)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStr(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return string.Empty;
            else
                return Convert.ToString(obj);
        }
        /// <summary>
        /// Object转化为decimal类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return 0;
            else
                return Convert.ToDecimal(obj);

        }


        #endregion
    }
}
