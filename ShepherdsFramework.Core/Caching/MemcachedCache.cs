// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.MemcachedCache
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Web;

namespace ShepherdsFramework.Core.Caching
{
    /// <summary>
    /// 用于连接Memcached的分布式缓存
    /// 
    /// </summary>
    public class MemcachedCache : ICache
    {
        private MemcachedClient cache = new MemcachedClient();

        /// <summary>
        /// 加入缓存项
        /// 
        /// </summary>
        /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间</param>
        public void Add(string key, object value, TimeSpan timeSpan)
        {
            key = key.ToLower();
            this.cache.Store(StoreMode.Set, key, value, DateTime.Now.Add(timeSpan));
        }

        /// <summary>
        /// 加入依赖物理文件的缓存项
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 主要应用于配置文件或配置项
        /// </remarks>
        /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="fullFileNameOfFileDependency">依赖的文件全路径</param>
        public void AddWithFileDependency(string key, object value, string fullFileNameOfFileDependency)
        {
            this.Add(key, value, new TimeSpan(30, 0, 0, 0));
        }

        /// <summary>
        /// 如果不存在缓存项则添加，否则更新
        /// 
        /// </summary>
        /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间</param>
        public void Set(string key, object value, TimeSpan timeSpan)
        {
            this.Add(key, value, timeSpan);
        }

        /// <summary>
        /// 标识删除
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 由于DB读写分离导致只读DB会有延迟，为保证缓存中的数据时时更新，需要在缓存中设置实体缓存为已删除状态
        /// 
        /// </remarks>
        /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间间隔</param>
        public void MarkDeletion(string key, object value, TimeSpan timeSpan)
        {
            this.Set(key, value, timeSpan);
        }

        /// <summary>
        /// 获取缓存项
        /// 
        /// </summary>
        /// <param name="cacheKey">cacheKey</param>
        public object Get(string cacheKey)
        {
            cacheKey = cacheKey.ToLower();
            HttpContext current = HttpContext.Current;
            if (current != null && current.Items.Contains(cacheKey))
                return current.Items[cacheKey];
            object obj = this.cache.Get(cacheKey);
            if (current != null && obj != null)
                current.Items[cacheKey] = obj;
            return obj;
        }

        /// <summary>
        /// 移除缓存项
        /// 
        /// </summary>
        /// <param name="cacheKey">cacheKey</param>
        public void Remove(string cacheKey)
        {
            cacheKey = cacheKey.ToLower();
            this.cache.Remove(cacheKey);
        }

        /// <summary>
        /// 清空缓存
        /// 
        /// </summary>
        public void Clear()
        {
            this.cache.FlushAll();
        }

        /// <summary>
        /// 获取缓存服务器统计信息
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public Dictionary<string, Dictionary<string, string>> GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
