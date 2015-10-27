using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Framework.Model
{
    /// <summary>
    /// 系统消息页面
    /// </summary>
    public class SystemMessageModel
    {
        /// <summary>
        /// 消息提示页面的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 主要的提示信息（可能需要在提示信息上加上占位符:{0}）
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 主要提示信息上的链接
        /// </summary>
        public Dictionary<string, string> BodyLink { get; set; }
        /// <summary>
        /// 返回上一页的链接
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 没有权限页面提示
        /// </summary>
        /// <returns></returns>
        public static SystemMessageModel NoCompetence()
        {
            return new SystemMessageModel
            {
                Body = "您没有权限查看此页面",
                Title = "没有权限"
            };
        }
        /// <summary>
        /// 没有找到内容提醒
        /// </summary>
        /// <returns></returns>
        public static SystemMessageModel NotFound()
        {
            return new SystemMessageModel
            {
                Body = "没有找到对应的内容",
                Title = "无内容"
            };
        }
    }
}
