using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Tool;

namespace ShepherdsFramework.Core.Caching.CacheManager
{
    /// <summary>
    /// CacheManager.Net 通用缓存接口适配器
    /// </summary>
    public class CacheManagerFactoryAdapter
    {
        private static bool _isconfigLoads;

        public CacheManagerFactoryAdapter() : this("~/Config/Cachemanager.config")
        {

        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="configpath"></param>
        public CacheManagerFactoryAdapter(string configpath)
        {
            if(CacheManagerFactoryAdapter._isconfigLoads) return;
            if (string.IsNullOrEmpty(configpath)) configpath = "~/Config/Cachemanager.config";
            FileInfo fileInfo = new FileInfo(WebUtility.GetPhysicalFilePath(configpath));
            if (!fileInfo.Exists) throw new ApplicationException(string.Format("Cachemanager的配置文件 {0} 没有找到", fileInfo.Name));
            
            CacheManagerFactoryAdapter._isconfigLoads = true;
        }
    }
}
