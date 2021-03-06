﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    /// <summary>
    /// 验证码可用字符集
    /// </summary>
    public enum CaptchaCharacterSet
    {
        /// <summary>
        /// 小写字母
        /// </summary>
        LowercaseLetters = 1,
        /// <summary>
        /// 大写字母
        /// </summary>
        UppercaseLetters = 2,
        /// <summary>
        ///大小写混合
        /// </summary>
        Letters = LowercaseLetters | UppercaseLetters,
        /// <summary>
        /// 数字0-9
        /// </summary>
        Digits = 4,
        /// <summary>
        /// 数字字母混合 
        /// </summary>
        LettersAndDigits = Letters | Digits
    }
}
