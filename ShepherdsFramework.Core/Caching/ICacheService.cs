// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.ICacheService
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

using System;

namespace ShepherdsFramework.Core.Caching
{
  /// <summary>
  /// 缓存服务接口
  /// 
  /// </summary>
  /// 
  /// <example>
  /// 
  /// <para>
  /// 使用缓存功能时，建议通过DI容器参照以下代码进行注册：
  /// </para>
  /// 
  /// <code language="c#">
  /// <![CDATA[
  ///             //注册缓存
  ///             containerBuilder.Register(c => new DefaultCacheService(new RuntimeMemoryCache(), new RuntimeMemoryCache(), 1.0F, true))
  ///                 .As<ICacheService>().SingleInstance();
  ///           ]]>
  /// </code>
  /// 
  /// </example>
  public interface ICacheService
  {
    /// <summary>
    /// 是否启用分布式缓存
    /// 
    /// </summary>
    bool EnableDistributedCache { get; }

    /// <summary>
    /// 添加到缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="cachingExpirationType">缓存期限类型</param>
    void Add(string cacheKey, object value, CachingExpirationType cachingExpirationType);

    /// <summary>
    /// 添加到缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间</param>
    void Add(string cacheKey, object value, TimeSpan timeSpan);

    /// <summary>
    /// 添加或更新缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="cachingExpirationType">缓存期限类型</param>
    void Set(string cacheKey, object value, CachingExpirationType cachingExpirationType);

    /// <summary>
    /// 添加或更新缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间间隔</param>
    void Set(string cacheKey, object value, TimeSpan timeSpan);

    /// <summary>
    /// 移除缓存
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    void Remove(string cacheKey);

    /// <summary>
    /// 标识为删除
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param><param name="entity">缓存的实体</param><param name="cachingExpirationType">缓存期限类型</param>
    void MarkDeletion(string cacheKey, BaseEntity entity, CachingExpirationType cachingExpirationType);

    /// <summary>
    /// 清空缓存
    /// 
    /// </summary>
    void Clear();

    /// <summary>
    /// 从缓存获取
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    object Get(string cacheKey);

    /// <summary>
    /// 从缓存获取(缓存项必须是引用类型)
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 支持 class,Array,Collection,delegate
    /// </remarks>
    /// <typeparam name="T">缓存项类型</typeparam><param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    T Get<T>(string cacheKey) where T : class;

    /// <summary>
    /// 从一层缓存获取
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    object GetFromFirstLevel(string cacheKey);

    /// <summary>
    /// 从一层缓存获取(缓存项必须是引用类型)
    /// 
    /// </summary>
    /// <typeparam name="T">缓存项类型</typeparam><param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    T GetFromFirstLevel<T>(string cacheKey) where T : class;
  }
}
