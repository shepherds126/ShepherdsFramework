// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.IListCacheSetting
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

namespace ShepherdsFramework.Core.Caching
{
  /// <summary>
  /// 用于列表缓存设置接口
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// 用于在查询对象中设置缓存策略
  /// </remarks>
  /// 
  /// <example>
  /// 
  /// <para>
  /// 为了更方便的使用列表缓存过期策略，可以在定义查询对象时实现IListCacheSetting，例如：
  /// </para>
  /// 
  /// <code language="c#">
  /// <![CDATA[
  ///     public class DiscussQuestionQuery : IListCacheSetting
  ///     {
  ///         public DiscussQuestionQuery(CacheVersionTypes cacheVersionType)
  ///         {
  ///             this.cacheVersionType = cacheVersionType;
  ///         }
  /// 
  ///         public long? UserId = null;
  /// 
  ///         //实体以外的查询条件的缓存分区需要自行处理
  ///         //public string TagName = null;
  /// 
  ///         public SortBy_SocialDiscuss SortBy = SortBy_SocialDiscuss.DateCreated;
  /// 
  /// 
  ///         #region IListCacheSetting 成员
  /// 
  ///         private CacheVersionTypes cacheVersionType = CacheVersionTypes.None;
  ///         /// <summary>
  ///         /// 列表缓存版本设置
  ///         /// </summary>
  ///         CacheVersionTypes IListCacheSetting.CacheVersionType
  ///         {
  ///             get { return cacheVersionType; }
  ///         }
  /// 
  ///         private string areaCachePropertyName = null;
  ///         /// <summary>
  ///         /// 缓存分区字段名称
  ///         /// </summary>
  ///         public string AreaCachePropertyName
  ///         {
  ///             get { return areaCachePropertyName; }
  ///             set { areaCachePropertyName = value; }
  ///         }
  /// 
  ///         private object areaCachePropertyValue = null;
  ///         /// <summary>
  ///         /// 缓存分区字段值
  ///         /// </summary>
  ///         public object AreaCachePropertyValue
  ///         {
  ///             get { return areaCachePropertyValue; }
  ///             set { areaCachePropertyValue = value; }
  ///         }
  /// 
  ///         #endregion
  /// 
  ///         ......
  /// 
  ///     }
  ///           ]]>
  /// </code>
  /// 
  /// </example>
  public interface IListCacheSetting
  {
    /// <summary>
    /// 列表缓存版本设置
    /// 
    /// </summary>
    CacheVersionType CacheVersionType { get; }

    /// <summary>
    /// 缓存分区字段名称
    /// 
    /// </summary>
    string AreaCachePropertyName { get; set; }

    /// <summary>
    /// 缓存分区字段值
    /// 
    /// </summary>
    object AreaCachePropertyValue { get; set; }
  }
}
