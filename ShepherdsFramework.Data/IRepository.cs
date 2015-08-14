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
        /// 获得一张数据表
        /// </summary>
        IQueryable<T> Table { get; }

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
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">entities</param>
        void Insert(IEnumerable<T> entities);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 更新实体集合
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<T> entities);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 删除实体集合
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);

    }
}
