using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core
{
    public class PageList<T>:List<T>,IPageList<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PageList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count = source.Count();
            this.TotalCount = count;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool IsPreviousPage {
            get { return PageIndex > 0; }
        }

        public bool IsNextPage
        {
            get { return PageIndex + 1 < TotalPages; }
        }
    }
}
