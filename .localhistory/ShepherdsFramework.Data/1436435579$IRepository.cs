using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;


namespace ShepherdsFramework.Data
{
    public partial interface  IRepository<T> where T:BaseEntity
    {
        /// <summary>
        /// 通过Id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

    }
}
