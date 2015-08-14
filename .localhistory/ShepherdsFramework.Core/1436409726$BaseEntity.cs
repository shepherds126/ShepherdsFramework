using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// 数据库模型基类
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// 实体唯一Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 逻辑删除标记
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 版本控制标记（用于处理并发）
        /// </summary>
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
