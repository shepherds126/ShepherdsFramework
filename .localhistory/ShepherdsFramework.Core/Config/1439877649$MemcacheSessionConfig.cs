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
        /// 查询超时时间
        /// </summary>
        private int _queuetimeout;
        /// <summary>
        /// 接收超时时间
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

        /// <summary>
        /// 
        /// </summary>
        public List<string> ServerList
        {
            get { return _serverlist; }
            set { _serverlist = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MinPoolSize
        {
            get { return _minpoolsize; }
            set { _minpoolsize = value; }
        }

        public int MaxPoolSize
        {
            get { return _maxpoolsize; }
            set { _maxpoolsize = value; }
        }

        public int ConnectionTimeOut
        {
            get { return _connectiontimeout; }
            set { _connectiontimeout = value; }
        }

        public int QueueTimeOut
        {
            get { return _queuetimeout; }
            set { _queuetimeout = value; }
        }

    }
}
