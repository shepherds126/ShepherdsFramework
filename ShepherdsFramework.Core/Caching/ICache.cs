// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.ICache
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

using System;

namespace ShepherdsFramework.Core.Caching
{
  /// <summary>
  /// 缓存接口
  /// 
  /// </summary>
  public interface ICache
  {
    /// <summary>
    /// 加入缓存项
    /// 
    /// </summary>
    /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间</param>
    void Add(string key, object value, TimeSpan timeSpan);

    /// <summary>
    /// 加入依赖物理文件的缓存项
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 主要应用于配置文件或配置项
    /// </remarks>
    /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="fullFileNameOfFileDependency">依赖的文件全路径</param>
    void AddWithFileDependency(string key, object value, string fullFileNameOfFileDependency);

    /// <summary>
    /// 如果不存在缓存项则添加，否则更新
    /// 
    /// </summary>
    /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间</param>
    void Set(string key, object value, TimeSpan timeSpan);

    /// <summary>
    /// 标识删除
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 由于DB读写分离导致只读DB会有延迟，为保证缓存中的数据时时更新，需要在缓存中设置ID缓存为已删除状态
    /// 
    /// </remarks>
    /// <param name="key">缓存项标识</param><param name="value">缓存项</param><param name="timeSpan">缓存失效时间间隔</param>
    void MarkDeletion(string key, object value, TimeSpan timeSpan);

    /// <summary>
    /// 获取缓存项
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    /// <returns>
    /// 返回cacheKey对应的缓存项，如果不存在则返回null
    /// </returns>
    object Get(string cacheKey);

    /// <summary>
    /// 移除缓存项
    /// 
    /// </summary>
    /// <param name="cacheKey">缓存项标识</param>
    void Remove(string cacheKey);

    /// <summary>
    /// 清空缓存
    /// 
    /// </summary>
    void Clear();
  }
}
