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
        /// 
        /// </summary>
        private int _maxpoolsize;
        private int _connectiontimeout;
        private int _queuetimeout;
        private int _receivetimeout;
        private int _deadtimeout;
        private int _sessiontimeout;
    }
}
