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
        void InitConnectionFactory();
    }
}
