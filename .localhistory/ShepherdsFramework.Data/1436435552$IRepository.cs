using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;


namespace ShepherdsFramework.Data
{
    public partial interface  IRepository<T> where T:BaseEntity
    {
        T GetById(int Id);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

    }
}
