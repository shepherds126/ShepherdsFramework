using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Email.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailSetting
    {
        private int _batchSendLimit = 100;
        private string _adminEmailAddress = "";
        private string _noReplyAddress = "";
        private int _numberOftries = 6;
        private int _sendTimeInterval = 10;
        /// <summary>
        /// 每次从队列批量发送邮件的最大数量
        /// -1表示无限制
        /// </summary>
        public int BatchSendLimit
        {
            get { return _batchSendLimit; }
            set { _batchSendLimit = value; }
        }
        /// <summary>
        /// 管理员的Email地址
        /// </summary>
        public string AdminEmailAddress
        {
            get { return _adminEmailAddress; }
            set { _adminEmailAddress = value; }
        }
        /// <summary>
        /// NoReply邮件地址
        /// </summary>
        public string NoReplyAddress
        {
            get { return _noReplyAddress; }
            set { _noReplyAddress = value; }
        }
        /// <summary>
        /// 尝试发送的次数
        /// </summary>
        public int NumberOfTries
        {
            get { return _numberOftries; }
            set { _numberOftries = value; }
        }
        /// <summary>
        /// 邮件发送的间隔时间（以分为单位）
        /// </summary>
        public int SendTimeInterval
        {
            get { return _sendTimeInterval; }
            set { _sendTimeInterval = value; }
        }


    }
}
