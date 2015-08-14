using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core
{
    public interface IPageList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }

        int TotalCount { get; }
        int TotalPage { get; }
        bool IsPreviousPage { get; }
        bool IsNextPage { get; }
    }
}
