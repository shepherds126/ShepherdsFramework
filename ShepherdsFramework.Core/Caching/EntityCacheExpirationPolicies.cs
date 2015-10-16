// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.EntityCacheExpirationPolicies
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

namespace ShepherdsFramework.Core.Caching
{
    /// <summary>
    /// 实体缓存期限类型
    /// 
    /// </summary>
    public enum EntityCacheExpirationPolicies
    {
        /// <summary>
        /// 稳定数据
        /// </summary>
        Stable = 1,
        /// <summary>
        /// 常用的单个实体
        /// </summary>
        Usual = 3,
        /// <summary>
        /// 单个实体
        /// </summary>
        Normal = 5,
    }
}
