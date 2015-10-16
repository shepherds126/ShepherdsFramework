// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.DefaultCacheService
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

using System;
using System.Collections.Generic;

namespace ShepherdsFramework.Core.Caching
{
  /// <summary>
  /// 默认提供的缓存服务
  /// 
  /// </summary>
  [Serializable]
  public class DefaultCacheService : ICacheService
  {
    private ICache localCache;
    private ICache cache;
    private readonly Dictionary<CachingExpirationType, TimeSpan> cachingExpirationDictionary;
    private bool enableDistributedCache;

    /// <summary>
    /// 是否启用分布式缓存
    /// 
    /// </summary>
    public bool EnableDistributedCache
    {
      get
      {
        return this.enableDistributedCache;
      }
    }

    /// <summary>
    /// 构造函数(仅本机缓存)
    /// 
    /// </summary>
    /// <param name="cache">本机缓存</param><param name="cacheExpirationFactor">缓存过期时间因子</param>
    public DefaultCacheService(ICache cache, float cacheExpirationFactor)
      : this(cache, cache, cacheExpirationFactor, false)
    {
    }

    /// <summary>
    /// 构造函数
    /// 
    /// </summary>
    /// <param name="cache">缓存</param><param name="localCache">本机缓存</param><param name="cacheExpirationFactor">缓存过期时间因子</param><param name="enableDistributedCache">是否启用分布式缓存</param>
    public DefaultCacheService(ICache cache, ICache localCache, float cacheExpirationFactor, bool enableDistributedCache)
    {
      this.cache = cache;
      this.localCache = localCache;
      this.enableDistributedCache = enableDistributedCache;
      this.cachingExpirationDictionary = new Dictionary<CachingExpirationType, TimeSpan>();
      this.cachingExpirationDictionary.Add(CachingExpirationType.Invariable, new TimeSpan(0, 0, (int) (86400.0 *  cacheExpirationFactor)));
      this.cachingExpirationDictionary.Add(CachingExpirationType.Stable, new TimeSpan(0, 0, (int) (28800.0 *  cacheExpirationFactor)));
      this.cachingExpirationDictionary.Add(CachingExpirationType.RelativelyStable, new TimeSpan(0, 0, (int) (7200.0 *  cacheExpirationFactor)));
      this.cachingExpirationDictionary.Add(CachingExpirationType.UsualSingleObject, new TimeSpan(0, 0, (int) (600.0 *  cacheExpirationFactor)));
      this.cachingExpirationDictionary.Add(CachingExpirationType.UsualObjectCollection, new TimeSpan(0, 0, (int) (300.0 *  cacheExpirationFactor)));
      this.cachingExpirationDictionary.Add(CachingExpirationType.SingleObject, new TimeSpan(0, 0, (int) (180.0 *  cacheExpirationFactor)));
      this.cachingExpirationDictionary.Add(CachingExpirationType.ObjectCollection, new TimeSpan(0, 0, (int) (180.0 *  cacheExpirationFactor)));
    }

    /// <summary>
    /// 添加到缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="cachingExpirationType">缓存期限类型</param>
    public void Add(string cacheKey, object value, CachingExpirationType cachingExpirationType)
    {
      this.Add(cacheKey, value, this.cachingExpirationDictionary[cachingExpirationType]);
    }

    /// <summary>
    /// 添加到缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间间隔</param>
    public void Add(string cacheKey, object value, TimeSpan timeSpan)
    {
      this.cache.Add(cacheKey, value, timeSpan);
    }

    /// <summary>
    /// 添加或更新缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="cachingExpirationType">缓存期限类型</param>
    public void Set(string cacheKey, object value, CachingExpirationType cachingExpirationType)
    {
      this.Set(cacheKey, value, this.cachingExpirationDictionary[cachingExpirationType]);
    }

    /// <summary>
    /// 添加或更新缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间间隔</param>
    public void Set(string cacheKey, object value, TimeSpan timeSpan)
    {
      this.cache.Set(cacheKey, value, timeSpan);
    }

    /// <summary>
    /// 移除缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    public void Remove(string cacheKey)
    {
      this.cache.Remove(cacheKey);
    }

    /// <summary>
    /// 标识为删除
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="entity">缓存的实体</param><param name="cachingExpirationType">缓存期限类型</param>
    public void MarkDeletion(string cacheKey, IEntity entity, CachingExpirationType cachingExpirationType)
    {
      entity.IsDeletedInDatabase = true;
      this.cache.MarkDeletion(cacheKey,  entity, this.cachingExpirationDictionary[cachingExpirationType]);
    }

    /// <summary>
    /// 清空缓存
    /// 
    /// </summary>
    public void Clear()
    {
      this.cache.Clear();
    }

    /// <summary>
    /// 从缓存获取
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    public object Get(string cacheKey)
    {
      object obj = null;
      if (this.enableDistributedCache)
        obj = this.localCache.Get(cacheKey);
      if (obj == null)
      {
        obj = this.cache.Get(cacheKey);
        if (this.enableDistributedCache)
          this.localCache.Add(cacheKey, obj, this.cachingExpirationDictionary[CachingExpirationType.SingleObject]);
      }
      return obj;
    }

    public T Get<T>(string cacheKey) where T : class
    {
      object obj = this.Get(cacheKey);
      if (obj != null)
        return obj as T;
      return default (T);
    }

    /// <summary>
    /// 从一层缓存获取缓存项
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 在启用分布式缓存的情况下，指穿透二级缓存从一层缓存（分布式缓存）读取
    /// 
    /// </remarks>
    /// <param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    public object GetFromFirstLevel(string cacheKey)
    {
      return this.cache.Get(cacheKey);
    }

    /// <summary>
    /// 从一层缓存获取缓存项
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 在启用分布式缓存的情况下，指穿透二级缓存从一层缓存（分布式缓存）读取
    /// 
    /// </remarks>
    /// <typeparam name="T">缓存项类型</typeparam><param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    public T GetFromFirstLevel<T>(string cacheKey) where T : class
    {
      object fromFirstLevel = this.GetFromFirstLevel(cacheKey);
      if (fromFirstLevel != null)
        return fromFirstLevel as T;
      return default (T);
    }
  }
}
