using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// 对称加密算法
    /// 
    /// </summary>
    public class SymmetricEncrypt
    {
        private SymmetricEncryptType _mbytEncryptionType;
        private string _mstrOriginalString;
        private string _mstrEncryptedString;
        private SymmetricAlgorithm _mCSP;

        /// <summary>
        /// 加密类型
        /// 
        /// </summary>
        public SymmetricEncryptType EncryptionType
        {
            get
            {
                return this._mbytEncryptionType;
            }
            set
            {
                if (this._mbytEncryptionType == value)
                    return;
                this._mbytEncryptionType = value;
                this._mstrOriginalString = string.Empty;
                this._mstrEncryptedString = string.Empty;
                this.SetEncryptor();
            }
        }

        /// <summary>
        /// 对称加密算法提供者
        /// 
        /// </summary>
        public SymmetricAlgorithm CryptoProvider
        {
            get
            {
                return this._mCSP;
            }
            set
            {
                this._mCSP = value;
            }
        }

        /// <summary>
        /// 原始字符串
        /// 
        /// </summary>
        public string OriginalString
        {
            get
            {
                return this._mstrOriginalString;
            }
            set
            {
                this._mstrOriginalString = value;
            }
        }

        /// <summary>
        /// 加密后的字符
        /// 
        /// </summary>
        public string EncryptedString
        {
            get
            {
                return this._mstrEncryptedString;
            }
            set
            {
                this._mstrEncryptedString = value;
            }
        }

        /// <summary>
        /// 对称加密算法密钥
        /// 
        /// </summary>
        public byte[] key
        {
            get
            {
                return this._mCSP.Key;
            }
            set
            {
                this._mCSP.Key = value;
            }
        }

        /// <summary>
        /// 加密密钥
        /// 
        /// </summary>
        public string KeyString
        {
            get
            {
                return Convert.ToBase64String(this._mCSP.Key);
            }
            set
            {
                this._mCSP.Key = Convert.FromBase64String(value);
            }
        }

        /// <summary>
        /// 初始化向量
        /// 
        /// </summary>
        public byte[] IV
        {
            get
            {
                return this._mCSP.IV;
            }
            set
            {
                this._mCSP.IV = value;
            }
        }

        /// <summary>
        /// 初始化向量(Base64)
        /// 
        /// </summary>
        public string IVString
        {
            get
            {
                return Convert.ToBase64String(this._mCSP.IV);
            }
            set
            {
                this._mCSP.IV = Convert.FromBase64String(value);
            }
        }

        /// <summary>
        /// 默认采用DES算法
        /// 
        /// </summary>
        public SymmetricEncrypt()
        {
            this._mbytEncryptionType = SymmetricEncryptType.DES;
            this.SetEncryptor();
        }

        /// <summary>
        /// 构造函数
        /// 
        /// </summary>
        /// <param name="encryptionType">加密类型</param>
        public SymmetricEncrypt(SymmetricEncryptType encryptionType)
        {
            this._mbytEncryptionType = encryptionType;
            this.SetEncryptor();
        }

        /// <summary>
        /// 构造行数
        /// 
        /// </summary>
        /// <param name="encryptionType">加密类型</param><param name="originalString">原始字符串</param>
        public SymmetricEncrypt(SymmetricEncryptType encryptionType, string originalString)
        {
            this._mbytEncryptionType = encryptionType;
            this._mstrOriginalString = originalString;
            this.SetEncryptor();
        }

        /// <summary>
        /// 进行对称加密
        /// 
        /// </summary>
        public string Encrypt()
        {
            ICryptoTransform encryptor = this._mCSP.CreateEncryptor(this._mCSP.Key, this._mCSP.IV);
            byte[] bytes = Encoding.Unicode.GetBytes(this._mstrOriginalString);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            this._mstrEncryptedString = Convert.ToBase64String(memoryStream.ToArray());
            return this._mstrEncryptedString;
        }

        /// <summary>
        /// 进行对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        public string Encrypt(string originalString)
        {
            this._mstrOriginalString = originalString;
            return this.Encrypt();
        }

        /// <summary>
        /// 进行对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param><param name="encryptionType">加密类型</param>
        public string Encrypt(string originalString, SymmetricEncryptType encryptionType)
        {
            this._mstrOriginalString = originalString;
            this._mbytEncryptionType = encryptionType;
            return this.Encrypt();
        }

        /// <summary>
        /// 进行对称解密
        /// 
        /// </summary>
        public string Decrypt()
        {
            ICryptoTransform decryptor = this._mCSP.CreateDecryptor(this._mCSP.Key, this._mCSP.IV);
            byte[] buffer = Convert.FromBase64String(this._mstrEncryptedString);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Write);
            cryptoStream.Write(buffer, 0, buffer.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            this._mstrOriginalString = Encoding.Unicode.GetString(memoryStream.ToArray());
            return this._mstrOriginalString;
        }

        /// <summary>
        /// 进行对称解密
        /// 
        /// </summary>
        /// <param name="encryptedString">需要解密的字符串</param>
        public string Decrypt(string encryptedString)
        {
            this._mstrEncryptedString = encryptedString;
            return this.Decrypt();
        }

        /// <summary>
        /// 进行对称解密
        /// 
        /// </summary>
        /// <param name="encryptedString">需要解密的字符串</param><param name="encryptionType">字符串加密类型</param>
        public string Decrypt(string encryptedString, SymmetricEncryptType encryptionType)
        {
            this._mstrEncryptedString = encryptedString;
            this._mbytEncryptionType = encryptionType;
            return this.Decrypt();
        }

        /// <summary>
        /// 设置加密算法
        /// 
        /// </summary>
        private void SetEncryptor()
        {
            switch (this._mbytEncryptionType)
            {
                case SymmetricEncryptType.DES:
                    this._mCSP = (SymmetricAlgorithm)new DESCryptoServiceProvider();
                    break;
                case SymmetricEncryptType.RC2:
                    this._mCSP = (SymmetricAlgorithm)new RC2CryptoServiceProvider();
                    break;
                case SymmetricEncryptType.Rijndael:
                    this._mCSP = (SymmetricAlgorithm)new RijndaelManaged();
                    break;
                case SymmetricEncryptType.TripleDES:
                    this._mCSP = (SymmetricAlgorithm)new TripleDESCryptoServiceProvider();
                    break;
            }
            this._mCSP.GenerateKey();
            this._mCSP.GenerateIV();
        }

        /// <summary>
        /// 生成随机密钥
        /// 
        /// </summary>
        public string GenerateKey()
        {
            this._mCSP.GenerateKey();
            return Convert.ToBase64String(this._mCSP.Key);
        }

        /// <summary>
        /// 生成随机初始化向量
        /// 
        /// </summary>
        public string GenerateIV()
        {
            this._mCSP.GenerateIV();
            return Convert.ToBase64String(this._mCSP.IV);
        }
    }
}
