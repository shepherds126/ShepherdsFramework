// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.CachingExpirationType
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

namespace ShepherdsFramework.Core.Caching
{
  /// <summary>
  /// 缓存期限类型
  /// 
  /// </summary>
  public enum CachingExpirationType
  {
    /// <summary>
    /// 永久不变的
    /// </summary>
    Invariable,
    /// <summary>
    /// 稳定数据
    /// </summary>
    Stable,
    /// <summary>
    /// 相对稳定
    /// </summary>
    RelativelyStable,
    /// <summary>
    /// 常用的单个对象
    /// </summary>
    UsualSingleObject,
    /// <summary>
    /// 常用的对象集合
    /// </summary>
    UsualObjectCollection,
    /// <summary>
    /// 单个对象
    /// </summary>
    SingleObject,
    /// <summary>
    /// 对象集合
    /// </summary>
    ObjectCollection,
  }
}
