using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// 加密工具类
    /// 
    /// </summary>
    public static class EncryptionUtility
    {
        /// <summary>
        /// 对称加密
        /// 
        /// </summary>
        /// <param name="encryptType">加密类型</param><param name="str">需要加密的字符串</param><param name="ivString">初始化向量</param><param name="keyString">加密密钥</param>
        /// <returns>
        /// 加密后的字符串
        /// </returns>
        public static string SymmetricEncrypt(SymmetricEncryptType encryptType, string str, string ivString, string keyString)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(ivString) || string.IsNullOrEmpty(keyString))
                return str;
            return new SymmetricEncrypt(encryptType)
            {
                IVString = ivString,
                KeyString = keyString
            }.Encrypt(str);
        }

        /// <summary>
        /// 对称解密
        /// 
        /// </summary>
        /// <param name="encryptType">加密类型</param><param name="str">需要加密的字符串</param><param name="ivString">初始化向量</param><param name="keyString">加密密钥</param>
        /// <returns>
        /// 解密后的字符串
        /// </returns>
        public static string SymmetricDncrypt(SymmetricEncryptType encryptType, string str, string ivString, string keyString)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return new SymmetricEncrypt(encryptType)
            {
                IVString = ivString,
                KeyString = keyString
            }.Decrypt(str);
        }

        /// <summary>
        /// 标准MD5加密
        /// 
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>
        /// 加密后的字符串
        /// </returns>
        public static string MD5(string str)
        {
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str));
            string str1 = "";
            for (int index = 0; index < hash.Length; ++index)
                str1 += hash[index].ToString("x").PadLeft(2, '0');
            return str1;
        }

        /// <summary>
        /// 16位的MD5加密
        /// 
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns>
        /// 加密后的字符串
        /// </returns>
        public static string MD5_16(string str)
        {
            return EncryptionUtility.MD5(str).Substring(8, 16);
        }

        /// <summary>
        /// base64编码
        /// 
        /// </summary>
        /// <param name="str">待编码的字符串</param>
        /// <returns>
        /// 编码后的字符串
        /// </returns>
        public static string Base64_Encode(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>
        /// base64解码
        /// 
        /// </summary>
        /// <param name="str">待解码的字符串</param>
        /// <returns>
        /// 解码后的字符串
        /// </returns>
        public static string Base64_Decode(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
