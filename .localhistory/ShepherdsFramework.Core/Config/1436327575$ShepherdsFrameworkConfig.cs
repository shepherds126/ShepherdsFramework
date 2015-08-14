using System;
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
        /// <summary>
        /// 配置策略
        /// </summary>
        private static IConfigStrategy _configStrategy = null;
        /// <summary>
        /// 关系数据库配置信息
        /// </summary>
        private static RDBSConfigInfo _rdbsConfigInfo = null;
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ShepherdsFrameworkConfig()
        {

        }

        /// <summary>
        /// 关系数据库配置信息
        /// </summary>
        public static RDBSConfigInfo RDBSConfig
        {
            get { return _rdbsConfigInfo; }
        }
    }
}
