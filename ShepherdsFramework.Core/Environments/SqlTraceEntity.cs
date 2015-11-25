using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Environments
{
    /// <summary>
    /// 用于Sql语句的跟踪的实体
    /// </summary>
    public class SqlTraceEntity
    {
        /// <summary>
        /// 跟踪的sql语句
        /// </summary>
        public string Sql { get; set; }
        /// <summary>
        /// 执行的时间（毫秒）
        /// </summary>
        public long ElapsedMilliseconds { get; set; }
    }
}
