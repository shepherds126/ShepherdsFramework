using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Domain.Logs
{
    /// <summary>
    /// 操作人信息
    /// </summary>
    public partial class OperatorInfo
    {
        /// <summary>
        /// 操作者的Id
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 操作者名称
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作者IP
        /// </summary>
        public string OperatorIP { get; set; }
        /// <summary>
        /// 访问的Url
        /// </summary>
        public string AccessUrl { get; set; }
    }
}
