using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// 数据库支持接口
    /// </summary>
   public interface IDataProvider
    {
        /// <summary>
        /// 初始化数据库连接接口
        /// </summary>
        void InitConnectionFactory();
        /// <summary>
        /// 数据库初始化接口
        /// </summary>
        void InitDatabase();
        /// <summary>
        /// 数据库初始化器接口
        /// </summary>
        void SetDatabaseInitializer();
    }
}
