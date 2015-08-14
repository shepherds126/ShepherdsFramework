﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// ShepherdsFramework配置管理类
    /// </summary>
    public partial class ShepherdsFrameworkConfig
    {
        /// <summary>
        /// 锁对象
        /// </summary>
        private static object _locker = new object();

        private static IConfigStrategy _configStrategy = null;
    }
}
