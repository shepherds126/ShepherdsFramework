// Decompiled with JetBrains decompiler
// Type: Tunynet.Caching.RealTimeCacheHelper
// Assembly: Tunynet.Infrastructure, Version=2.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ED557113-DD0D-47C8-B68D-4965396F532B
// Assembly location: E:\解决方案参考\近乎4.3.0.0免费源码\近乎_V4.3.0.0_免费源码版\packages\Tunynet.Infrastructure.2.2.0\lib\net40\Tunynet.Infrastructure.dll

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ShepherdsFramework.Core.DependencyManagement;

namespace ShepherdsFramework.Core.Caching
{
    /// <summary>
    /// 实时性缓存助手
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 主要有两个作用：递增缓存版本号、获取缓存CacheKey
    /// 
    /// </remarks>
    [Serializable]
    public class RealTimeCacheHelper
    {
        /// <summary>
        /// 线程安全的字典集合，使用了细粒度锁，在多线程写入方面比使用锁的通常的字典的伸缩性好
        /// </summary>
        private ConcurrentDictionary<object, int> entityVersionDictionary = new ConcurrentDictionary<object, int>();

        private ConcurrentDictionary<string, ConcurrentDictionary<int, int>> areaVersionDictionary =
            new ConcurrentDictionary<string, ConcurrentDictionary<int, int>>();

        private int globalVersion;

        /// <summary>
        /// 是否使用缓存
        /// 
        /// </summary>
        public bool EnableCache { get; private set; }

        /// <summary>
        /// 缓存过期类型
        /// 
        /// </summary>
        public CachingExpirationType CachingExpirationType { get; set; }

        /// <summary>
        /// 缓存分区的属性
        /// 
        /// </summary>
        public IEnumerable<PropertyInfo> PropertiesOfArea { get; set; }

        /// <summary>
        /// 实体正文缓存对应的属性名称（如果不需单独存储实体正文缓存，则不要设置该属性）
        /// 
        /// </summary>
        public PropertyInfo PropertyNameOfBody { get; set; }

        /// <summary>
        /// 完整名称md5-16
        /// 
        /// </summary>
        public string TypeHashID { get; private set; }

        /// <summary>
        /// 构造函数
        /// 
        /// </summary>
        /// <param name="enableCache">是否启用缓存</param><param name="typeHashID">类型名称哈希值</param>
        public RealTimeCacheHelper(bool enableCache, string typeHashID)
        {
            this.EnableCache = enableCache;
            this.TypeHashID = typeHashID;
        }

        /// <summary>
        /// 列表缓存全局version
        /// 
        /// </summary>
        public int GetGlobalVersion()
        {
            return this.globalVersion;
        }

        /// <summary>
        /// 获取Entity的缓存版本
        /// 
        /// </summary>
        /// <param name="primaryKey">实体主键</param>
        /// <returns>
        /// 实体的缓存版本（从0开始）
        /// </returns>
        public int GetEntityVersion(object primaryKey)
        {
            int num = 0;
            this.entityVersionDictionary.TryGetValue(primaryKey, out num);
            return num;
        }

        /// <summary>
        /// 获取列表缓存区域version
        /// 
        /// </summary>
        /// <param name="propertyName">分区属性名称</param><param name="propertyValue">分区属性值</param>
        /// <returns>
        /// 分区属性的缓存版本（从0开始）
        /// </returns>
        public int GetAreaVersion(string propertyName, object propertyValue)
        {
            int num = 0;
            if (string.IsNullOrEmpty(propertyName))
                return num;
            propertyName = propertyName.ToLower();
            ConcurrentDictionary<int, int> concurrentDictionary;
            if (this.areaVersionDictionary.TryGetValue(propertyName, out concurrentDictionary))
                concurrentDictionary.TryGetValue(propertyValue.GetHashCode(), out num);
            return num;
        }

        /// <summary>
        /// 递增列表缓存全局版本
        /// 
        /// </summary>
        public void IncreaseGlobalVersion()
        {
            ++this.globalVersion;
        }

        /// <summary>
        /// 递增实体缓存（仅更新实体时需要递增）
        /// 
        /// </summary>
        /// <param name="entityId">实体Id</param>
        public void IncreaseEntityCacheVersion(object entityId)
        {
            if (!ContainerManager.Resolve<ICacheService>().EnableDistributedCache)
                return;
            int num1;
            int num2 = !this.entityVersionDictionary.TryGetValue(entityId, out num1) ? 1 : num1 + 1;
            this.entityVersionDictionary[entityId] = num2;
            this.OnChanged();
        }

        /// <summary>
        /// 递增列表缓存version（增加、更改、删除实体时需要递增）
        /// 
        /// </summary>
        /// <param name="entity">实体</param>
        public void IncreaseListCacheVersion(IEntity entity)
        {
            if (this.PropertiesOfArea != null)
            {
                foreach (PropertyInfo propertyInfo in this.PropertiesOfArea)
                {
                    object obj = propertyInfo.GetValue((object) entity, (object[]) null);
                    if (obj != null)
                        this.IncreaseAreaVersion(propertyInfo.Name.ToLower(), (IEnumerable<object>) new object[1]
                        {
                            obj
                        }, 0 != 0);
                }
            }
            this.IncreaseGlobalVersion();
            this.OnChanged();
        }

        /// <summary>
        /// 递增列表缓存区域version
        /// 
        /// </summary>
        /// <param name="propertyName">分区属性名称</param><param name="propertyValue">分区属性值</param>
        public void IncreaseAreaVersion(string propertyName, object propertyValue)
        {
            if (propertyValue == null)
                return;
            this.IncreaseAreaVersion(propertyName, (IEnumerable<object>) new object[1]
            {
                propertyValue
            }, 1 != 0);
        }

        /// <summary>
        /// 递增列表缓存区域version
        /// 
        /// </summary>
        /// <param name="propertyName">分区属性名称</param><param name="propertyValues">多个分区属性值</param>
        public void IncreaseAreaVersion(string propertyName, IEnumerable<object> propertyValues)
        {
            this.IncreaseAreaVersion(propertyName, propertyValues, true);
        }

        /// <summary>
        /// 递增列表缓存区域version
        /// 
        /// </summary>
        /// <param name="propertyName">分区属性名称</param><param name="propertyValues">多个分区属性值</param><param name="raiseChangeEvent">是否触发Change事件</param>
        private void IncreaseAreaVersion(string propertyName, IEnumerable<object> propertyValues, bool raiseChangeEvent)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;
            propertyName = propertyName.ToLower();
            int num = 0;
            ConcurrentDictionary<int, int> concurrentDictionary;
            if (!this.areaVersionDictionary.TryGetValue(propertyName, out concurrentDictionary))
            {
                this.areaVersionDictionary[propertyName] = new ConcurrentDictionary<int, int>();
                concurrentDictionary = this.areaVersionDictionary[propertyName];
            }
            foreach (object obj in propertyValues)
            {
                int hashCode = obj.GetHashCode();
                if (concurrentDictionary.TryGetValue(hashCode, out num))
                    ++num;
                else
                    num = 1;
                concurrentDictionary[hashCode] = num;
            }
            if (!raiseChangeEvent)
                return;
            this.OnChanged();
        }

        /// <summary>
        /// 标识为已删除
        /// 
        /// </summary>
        public void MarkDeletion(IEntity entity)
        {
            ICacheService cacheService = ContainerManager.Resolve<ICacheService>();
            if (!this.EnableCache)
                return;
            cacheService.MarkDeletion(this.GetCacheKeyOfEntity(entity.EntityId), entity,
                CachingExpirationType.SingleObject);
        }

        /// <summary>
        /// 获取实体缓存的cacheKey
        /// 
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>
        /// 实体的CacheKey
        /// </returns>
        public string GetCacheKeyOfEntity(object primaryKey)
        {
            if (!ContainerManager.Resolve<ICacheService>().EnableDistributedCache)
                return this.TypeHashID + (object) ":" + (string) primaryKey;
            return this.TypeHashID + (object) ":" + (string) primaryKey + ":" +
                   (string) (object) this.GetEntityVersion(primaryKey);
        }

        /// <summary>
        /// 获取实体正文缓存的cacheKey
        /// 
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns>
        /// 实体正文缓存的cacheKey
        /// </returns>
        public string GetCacheKeyOfEntityBody(object primaryKey)
        {
            if (!ContainerManager.Resolve<ICacheService>().EnableDistributedCache)
                return this.TypeHashID + (object) ":B-" + (string) primaryKey;
            return this.TypeHashID + (object) ":B-" + (string) primaryKey + ":" +
                   (string) (object) this.GetEntityVersion(primaryKey);
        }

        /// <summary>
        /// 获取列表缓存CacheKey的前缀（例如：abe3ds2sa90:8:）
        /// 
        /// </summary>
        /// <param name="cacheVersionSetting">列表缓存设置</param>
        /// <returns>
        /// 列表缓存CacheKey的前缀
        /// </returns>
        public string GetListCacheKeyPrefix(IListCacheSetting cacheVersionSetting)
        {
            StringBuilder stringBuilder = new StringBuilder(this.TypeHashID);
            stringBuilder.Append("-L:");
            switch (cacheVersionSetting.CacheVersionType)
            {
                case CacheVersionType.GlobalVersion:
                    stringBuilder.AppendFormat("{0}:", (object) this.GetGlobalVersion());
                    break;
                case CacheVersionType.AreaVersion:
                    stringBuilder.AppendFormat("{0}-{1}-{2}:", (object) cacheVersionSetting.AreaCachePropertyName,
                        (object) cacheVersionSetting.AreaCachePropertyValue.ToString(),
                        (object)
                            this.GetAreaVersion(cacheVersionSetting.AreaCachePropertyName,
                                cacheVersionSetting.AreaCachePropertyValue));
                    break;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 获取列表缓存CacheKey的前缀（例如：abe3ds2sa90:8:）
        /// 
        /// </summary>
        /// <param name="cacheVersionType">列表缓存版本设置</param>
        /// <returns>
        /// 列表缓存CacheKey的前缀
        /// </returns>
        public string GetListCacheKeyPrefix(CacheVersionType cacheVersionType)
        {
            return this.GetListCacheKeyPrefix(cacheVersionType, (string) null, (object) null);
        }

        /// <summary>
        /// 获取列表缓存CacheKey的前缀（例如：abe3ds2sa90:8:）
        /// 
        /// </summary>
        /// <param name="cacheVersionType"/><param name="areaCachePropertyName">缓存分区名称</param><param name="areaCachePropertyValue">缓存分区值</param>
        /// <returns/>
        public string GetListCacheKeyPrefix(CacheVersionType cacheVersionType, string areaCachePropertyName,
            object areaCachePropertyValue)
        {
            StringBuilder stringBuilder = new StringBuilder(this.TypeHashID);
            stringBuilder.Append("-L:");
            switch (cacheVersionType)
            {
                case CacheVersionType.GlobalVersion:
                    stringBuilder.AppendFormat("{0}:", (object) this.GetGlobalVersion());
                    break;
                case CacheVersionType.AreaVersion:
                    stringBuilder.AppendFormat("{0}-{1}-{2}:", (object) areaCachePropertyName, areaCachePropertyValue,
                        (object) this.GetAreaVersion(areaCachePropertyName, areaCachePropertyValue));
                    break;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 获取CacheTimelinessHelper的CacheKey
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// typeHashID对应类型的缓存设置CacheKey
        /// </returns>
        internal static string GetCacheKeyOfTimelinessHelper(string typeHashID)
        {
            return "CacheTimelinessHelper:" + typeHashID;
        }

        /// <summary>
        /// 对象变更时回调
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 在分布式缓存情况，需要把缓存设置存储到缓存中
        /// 
        /// </remarks>
        private void OnChanged()
        {
            ICacheService cacheService = ContainerManager.Resolve<ICacheService>();
            if (!cacheService.EnableDistributedCache)
                return;
            cacheService.Set(RealTimeCacheHelper.GetCacheKeyOfTimelinessHelper(this.TypeHashID), (object) this,
                CachingExpirationType.Invariable);
        }
    }
}
