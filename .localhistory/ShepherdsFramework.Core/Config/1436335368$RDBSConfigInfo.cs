using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// 关系数据库配置信息
    /// </summary>
    public class RDBSConfigInfo : IConfig
    {
        /// <summary>
        /// 关系数据库连接字符串
        /// </summary>
        public string RDBSConnectionString { get; set; }
        /// <summary>
        /// 表名前缀
        /// </summary>
        public string RDBSTablePrex { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string RDBSTableType { get; set; }
    }
}
