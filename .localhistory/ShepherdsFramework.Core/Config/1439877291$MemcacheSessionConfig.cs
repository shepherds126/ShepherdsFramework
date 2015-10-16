using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Config
{
    /// <summary>
    /// Memcached Session状态配置信息类
    /// </summary>
    public class MemcacheSessionConfig : IConfig
    {
        /// <summary>
        /// 服务器列表
        /// </summary>
        private List<string> _serverlist;
        /// <summary>
        /// 最小的连接池数目
        /// </summary>
        private int _minpoolsize;
        /// <summary>
        /// 最大的连接池数目
        /// </summary>
        private int _maxpoolsize;
        /// <summary>
        /// 连接超时时间
        /// </summary>
        private int _connectiontimeout;
        /// <summary>
        /// 
        /// </summary>
        private int _queuetimeout;
        /// <summary>
        /// 
        /// </summary>
        private int _receivetimeout;
        /// <summary>
        /// 宕机服务器检查时间
        /// </summary>
        private int _deadtimeout;
        /// <summary>
        /// 会话超时时间
        /// </summary>
        private int _sessiontimeout;
    }
}
