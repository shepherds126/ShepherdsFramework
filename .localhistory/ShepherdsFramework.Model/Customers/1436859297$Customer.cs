using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using ShepherdsFramework.Core;

namespace ShepherdsFramework.Model.Customers
{
    public class Customer:BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 上传头像
        /// </summary>
        public string Avtar { get; set; }
    }
}
