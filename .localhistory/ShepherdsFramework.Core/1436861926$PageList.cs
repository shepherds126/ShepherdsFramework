using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core
{
    public class PageList<T>:List<T>,IPageList<T>
    {
        public PageList(IQueryable<T> source,int pageIndex,int pageSize) 
    }
}
