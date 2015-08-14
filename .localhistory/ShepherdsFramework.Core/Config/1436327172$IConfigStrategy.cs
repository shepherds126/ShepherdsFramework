using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    /// <summary>
    /// 配置策略接口
    /// </summary>
   public partial interface IConfigStrategy
    {
       /// <summary>
       /// 获取关系数据库配置
       /// </summary>
       /// <returns></returns>
        RDBSConfigInfo GetRDBSConfigInfo();
    }
}
