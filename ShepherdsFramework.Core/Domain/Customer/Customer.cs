using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Domain.Customer
{
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            Id = 1;
        }

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
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 是否已激活
        /// </summary>
        public bool Actived { get; set; }
        /// <summary>
        /// 是否被封
        /// </summary>
        public bool Baned { get; set; }
    }
}
