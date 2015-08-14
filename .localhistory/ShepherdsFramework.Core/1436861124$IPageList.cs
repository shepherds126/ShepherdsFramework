using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core
{
    public interface IPageList<T> : IList<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        int PageIndex { get; }
        /// <summary>
        /// 每页包含的数目
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// 总数量
        /// </summary>
        int TotalCount { get; }
        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPage { get; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        bool IsPreviousPage { get; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        bool IsNextPage { get; }
    }
}
