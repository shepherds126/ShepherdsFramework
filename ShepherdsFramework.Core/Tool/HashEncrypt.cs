using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// 非对称加密算法
    /// 
    /// </summary>
    public class HashEncrypt
    {
        private string mstrSaltValue = string.Empty;
        private short msrtSaltLength = (short)8;
        private HashEncryptType _mbytHashType;
        private string _mstrOriginalString;
        private string _mstrHashString;
        private HashAlgorithm _mhash;
        private bool mboolUseSalt;

        /// <summary>
        /// 非对称加密类型
        /// 
        /// </summary>
        public HashEncryptType HashType
        {
            get
            {
                return this._mbytHashType;
            }
            set
            {
                if (this._mbytHashType == value)
                    return;
                this._mbytHashType = value;
                this._mstrOriginalString = string.Empty;
                this._mstrHashString = string.Empty;
                this.SetEncryptor();
            }
        }

        /// <summary>
        /// SaltValue
        /// 
        /// </summary>
        public string SaltValue
        {
            get
            {
                return this.mstrSaltValue;
            }
            set
            {
                this.mstrSaltValue = value;
            }
        }

        /// <summary>
        /// UseSalt
        /// 
        /// </summary>
        public bool UseSalt
        {
            get
            {
                return this.mboolUseSalt;
            }
            set
            {
                this.mboolUseSalt = value;
            }
        }

        /// <summary>
        /// SaltLength
        /// 
        /// </summary>
        public short SaltLength
        {
            get
            {
                return this.msrtSaltLength;
            }
            set
            {
                this.msrtSaltLength = value;
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
        /// 加密后的字符串
        /// 
        /// </summary>
        public string HashString
        {
            get
            {
                return this._mstrHashString;
            }
            set
            {
                this._mstrHashString = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// 
        /// </summary>
        public HashEncrypt()
        {
            this._mbytHashType = HashEncryptType.MD5;
        }

        /// <summary>
        /// 构造函数
        /// 
        /// </summary>
        /// <param name="hashType">加密类型</param>
        public HashEncrypt(HashEncryptType hashType)
        {
            this._mbytHashType = hashType;
        }

        /// <summary>
        /// 构造函数
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param><param name="hashType">加密类型</param>
        public HashEncrypt(HashEncryptType hashType, string originalString)
        {
            this._mbytHashType = hashType;
            this._mstrOriginalString = originalString;
        }

        /// <summary>
        /// 构造函数
        /// 
        /// </summary>
        /// <param name="hashType">加密类型</param><param name="originalString">原始字符串</param><param name="useSalt">是否使用散列</param><param name="saltValue">散列值（如果启用散列但没有传入散列值则使用随机生的散列值）</param>
        public HashEncrypt(HashEncryptType hashType, string originalString, bool useSalt, string saltValue)
        {
            this._mbytHashType = hashType;
            this._mstrOriginalString = originalString;
            this.mboolUseSalt = useSalt;
            this.mstrSaltValue = saltValue;
        }

        /// <summary>
        /// 设置加密算法
        /// 
        /// </summary>
        private void SetEncryptor()
        {
            switch (this._mbytHashType)
            {
                case HashEncryptType.MD5:
                    this._mhash = (HashAlgorithm)new MD5CryptoServiceProvider();
                    break;
                case HashEncryptType.SHA1:
                    this._mhash = (HashAlgorithm)new SHA1CryptoServiceProvider();
                    break;
                case HashEncryptType.SHA256:
                    this._mhash = (HashAlgorithm)new SHA256Managed();
                    break;
                case HashEncryptType.SHA384:
                    this._mhash = (HashAlgorithm)new SHA384Managed();
                    break;
                case HashEncryptType.SHA512:
                    this._mhash = (HashAlgorithm)new SHA512Managed();
                    break;
            }
        }

        /// <summary>
        /// 进行非对称加密
        /// 
        /// </summary>
        public string Encrypt()
        {
            this.SetEncryptor();
            if (this.mboolUseSalt && this.mstrSaltValue.Length == 0)
                this.mstrSaltValue = this.CreateSalt();
            return Convert.ToBase64String(this._mhash.ComputeHash(Encoding.UTF8.GetBytes(this.mstrSaltValue + this._mstrOriginalString)));
        }

        /// <summary>
        /// 进行非对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param>
        public string Encrypt(string originalString)
        {
            this._mstrOriginalString = originalString;
            return this.Encrypt();
        }

        /// <summary>
        /// 进行非对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param><param name="hashType">加密类型</param>
        public string Encrypt(string originalString, HashEncryptType hashType)
        {
            this._mstrOriginalString = originalString;
            this._mbytHashType = hashType;
            return this.Encrypt();
        }

        /// <summary>
        /// 进行非对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param><param name="useSalt">是否启用散列</param>
        public string Encrypt(string originalString, bool useSalt)
        {
            this._mstrOriginalString = originalString;
            this.mboolUseSalt = useSalt;
            return this.Encrypt();
        }

        /// <summary>
        /// 进行非对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param><param name="hashType">加密类型</param><param name="saltValue">散列值</param>
        public string Encrypt(string originalString, HashEncryptType hashType, string saltValue)
        {
            this._mstrOriginalString = originalString;
            this._mbytHashType = hashType;
            this.mstrSaltValue = saltValue;
            return this.Encrypt();
        }

        /// <summary>
        /// 进行非对称加密
        /// 
        /// </summary>
        /// <param name="originalString">原始字符串</param><param name="saltValue">散列值</param>
        public string Encrypt(string originalString, string saltValue)
        {
            this._mstrOriginalString = originalString;
            this.mstrSaltValue = saltValue;
            return this.Encrypt();
        }

        /// <summary>
        /// 重置加密设置
        /// 
        /// </summary>
        public void Reset()
        {
            this.mstrSaltValue = string.Empty;
            this._mstrOriginalString = string.Empty;
            this._mstrHashString = string.Empty;
            this.mboolUseSalt = false;
            this._mbytHashType = HashEncryptType.MD5;
            this._mhash = (HashAlgorithm)null;
        }

        /// <summary>
        /// 创建散列
        /// 
        /// </summary>
        public string CreateSalt()
        {
            byte[] numArray = new byte[8];
            new RNGCryptoServiceProvider().GetBytes(numArray);
            return Convert.ToBase64String(numArray);
        }
    }
}
