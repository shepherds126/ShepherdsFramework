using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;

namespace ShepherdsFramework.Data
{
    public interface IDbContext
    {
        /// <summary>
        /// dbset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IDbSet<T> Set<T>() where T : BaseEntity;
        /// <summary>
        /// save change
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 执行存储过程加载对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandtext"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IList<T> ExecuteStoredProcedureList<T>(string commandtext, params object[] parameters)
            where T : BaseEntity, new();
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);

        int ExecuteSqlCommand(string sql, bool isSureTransaction = false, params object[] parameters);

    }
}


