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

        public ShepherdsFrameworkDbContext() : base("default")
        {
        }

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
        /// <summary>
        /// sql字符串操作数据库
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="isensuretransaction">事务执行标记</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExcuteSqlCommand(string sql, bool isensuretransaction = false, params object[] parameters)
        {

        }
    }
}
