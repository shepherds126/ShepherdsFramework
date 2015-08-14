using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool IsDelete { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
