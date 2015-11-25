using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;
using CacheManager.Core.Configuration;
using ShepherdsFramework.Core.Tool;

namespace ShepherdsFramework.Core.Caching.CacheManager
{
    /// <summary>
    /// CacheManager.Net 通用缓存接口适配器
    /// </summary>
    public class CacheManagerFactoryAdapter: ICacheManagerFactoryAdapter
    {
        private static bool _isconfigLoads;
        private static string cachename = "myCache";

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
            if (string.IsNullOrEmpty(configpath)) configpath = "~/Config/cachemanager.config";
            FileInfo fileInfo = new FileInfo(WebUtility.GetPhysicalFilePath(configpath));
            if (!fileInfo.Exists) throw new ApplicationException(string.Format("cachemanager的配置文件 {0} 没有找到", fileInfo.Name));
            CacheManagerConfiguration cacheManagerConfiguration =  ConfigurationBuilder.LoadConfigurationFile(configpath, cachename);
            CacheFactory.FromConfiguration<object>(cachename, cacheManagerConfiguration); 
            CacheManagerFactoryAdapter._isconfigLoads = true;
        }
    }
}
