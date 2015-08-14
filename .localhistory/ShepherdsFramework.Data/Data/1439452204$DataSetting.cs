using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Data.Data
{
    /// <summary>
    /// 连接字符串解析类
    /// </summary>
    public partial class DataSetting
    {
        /// <summary>
        /// 提供
        /// </summary>
        public string DataProvider { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string DataConnectionString { get; set; }
    }
}
