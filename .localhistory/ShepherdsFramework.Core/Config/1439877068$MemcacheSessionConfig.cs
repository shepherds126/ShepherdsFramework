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
        private List<string> _serverlist;
        private int _minpoolsize;
        private int _maxpoolsize;
        private int _connectiontimeout;
        private int _queuetimeout;
        private int _receivetimeout
    }
}
