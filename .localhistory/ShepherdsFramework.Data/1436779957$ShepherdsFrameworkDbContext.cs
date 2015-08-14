using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Data
{
    /// <summary>
    /// 数据库上下文
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
    }
}
