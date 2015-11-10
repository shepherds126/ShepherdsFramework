using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Domain.Logs
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public partial class OperationLog : BaseEntity
    {
        /// <summary>
        /// 日志模块
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperationType { get; set; }
        /// <summary>
        /// 操作对象
        /// </summary>
        public string OperationObjectName { get; set; }
        /// <summary>
        /// 操作对象Id
        /// </summary>

        public string OperationObjectId { get; set; }
        /// <summary>
        /// 操作描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 操作者Id
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 操作者名称
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作者Ip
        /// </summary>
        public string OperatorIp { get; set; }
        /// <summary>
        /// 访问的Url
        /// </summary>
        public string AccessUrl { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        public OperationLog()
        {
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="operatorInfo"></param>
        public OperationLog(OperatorInfo operatorInfo)
        {
            this.OperatorId = operatorInfo.OperatorId;
            this.Operator = operatorInfo.Operator;
            this.AccessUrl = operatorInfo.AccessUrl;
            this.OperatorIp = operatorInfo.OperatorIP;
            this.DateCreate = DateTime.Now;
        }
    }
}
