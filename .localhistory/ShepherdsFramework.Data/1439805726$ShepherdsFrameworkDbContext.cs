using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using ShepherdsFramework.Core;
using ShepherdsFramework.Data.Mapping;

namespace ShepherdsFramework.Data
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class ShepherdsFrameworkDbContext : DbContext, IDbContext
    {


        public ShepherdsFrameworkDbContext() : base("SFDBRS")
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
        /// 通过反射将EF实体映射配置加入到实体模型中
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //获取实现EntityTypeConfiguration泛型类的所有程序集
            //动态加载所有的配置
            var typesToRegister =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => !String.IsNullOrEmpty(type.Namespace))
                    .Where(
                        type =>
                            type.BaseType != null && type.BaseType.IsGenericType &&
                            type.BaseType.GetGenericTypeDefinition() == typeof(ShepherdsFrameworkEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
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
        public int ExecuteSqlCommand(string sql, bool isensuretransaction = false, params object[] parameters)
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

               
            }
            var result = this.Database.SqlQuery<T>(commandtext, parameters).ToList();
            return result;
        }
        /// <summary>
        /// sql语句查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<T>(sql, parameters);
        }
    }
}
