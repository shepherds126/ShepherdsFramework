using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// 数据库支持接口
    /// </summary>
    interface IDataProvider
    {
        /// <summary>
        /// 连接字符串接口
        /// </summary>
        void InitConnectionFactory();
        /// <summary>
        /// 数据库初始化接口
        /// </summary>
        void InitDatabase();
        void SetDatabaseInitializer
    }
}
