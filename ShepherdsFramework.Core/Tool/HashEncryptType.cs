using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// 非对称加密类型
    /// 
    /// </summary>
    public enum HashEncryptType : byte
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512,
    }
}
