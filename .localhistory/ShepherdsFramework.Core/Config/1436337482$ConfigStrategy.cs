using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShepherdsFramework.Core
{
    public partial class ConfigStrategy:IConfigStrategy
    {
        /// <summary>
        /// 关系数据库配置文件
        /// </summary>
        private readonly string _rdbsconfigpath = "/Config/rdbs.config";


        public RDBSConfigInfo GetRDBSConfigInfo()
        {

        }

        private IConfig LoadConfig(Type configType, string configFile)
        {

        }
    }

}
