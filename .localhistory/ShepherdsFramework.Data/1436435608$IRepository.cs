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
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">entity</param>
        void Insert(T entity);

        void Insert(IEnumerable<T> entities);

    }
}
