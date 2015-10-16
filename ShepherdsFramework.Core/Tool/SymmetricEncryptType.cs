using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Tool
{
    /// <summary>
    /// 对称加密类型
    /// 
    /// </summary>
    public enum SymmetricEncryptType : byte
    {
        DES,
        RC2,
        Rijndael,
        TripleDES,
    }
}
