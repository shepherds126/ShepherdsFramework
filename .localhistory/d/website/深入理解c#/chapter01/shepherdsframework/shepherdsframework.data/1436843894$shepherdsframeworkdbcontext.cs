using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;

namespace ShepherdsFramework.Data
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class ShepherdsFrameworkDbContext : DbContext, IDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        public ShepherdsFrameworkDbContext(string connString) : base(connString)
        {
        }
        /// <summary>
        /// 获得一个实体集
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <returns></returns>
        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }
    }
}
