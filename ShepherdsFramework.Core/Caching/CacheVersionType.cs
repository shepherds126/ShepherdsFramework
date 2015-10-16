// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.CacheVersionType
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

namespace ShepherdsFramework.Core.Caching
{
    /// <summary>
    /// 列表缓存版本设置
    /// 
    /// </summary>
    public enum CacheVersionType
    {
        /// <summary>
        /// 不使用缓存版本
        /// </summary>
        None,
        /// <summary>
        /// 使用全局缓存版本
        /// </summary>
        GlobalVersion,
        /// <summary>
        /// 使用分区缓存版本
        /// </summary>
        AreaVersion,
    }
}
