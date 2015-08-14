﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
namespace ShepherdsFramework.Data
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class ShepherdsFrameworkDbContext : DbContext, IDbContext
    {

        public ShepherdsFrameworkDbContext() : base("default")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        public ShepherdsFrameworkDbContext(string connString) : base(connString)
        {
        }
        /// <summary>
        /// 获得一个实体集
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <returns></returns>
        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }
        /// <summary>
        /// sql字符串操作数据库
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="isensuretransaction">事务执行标记</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExcuteSqlCommand(string sql, bool isensuretransaction = false, params object[] parameters)
        {
            var transation = isensuretransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transation, sql, parameters);
            return result;
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="commandtext">sql语句</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IList<T> ExecuteStoredProcedureList<T>(string commandtext, params object[] parameters)
            where T : BaseEntity, new()
        {
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if(p == null) throw new Exception("不支持当前的参数类型");

                    commandtext += i == 0 ? "" : ",";
                    commandtext += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        commandtext += " output";
                    }
                }

                var result = this.Database.SqlQuery<T>(commandtext,parameters).ToList();
            }
        }
    }
}
