using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.DependencyManagement;
using ShepherdsFramework.Core.Logging;
using ShepherdsFramework.Core.Logging.SystemLog;

namespace ShepherdsFramework.Data
{
    /// <summary>
    /// EF仓储类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public EFRepository(IDbContext context)
        {
            this._context = context;
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        /// <summary>
        /// 通过id获得对应的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return this.Entities.Find(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("数据实体为空");
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var slog = ContainerManager.Resolve<ILogger>();
                var exception = dbex.ThrowDbEntityValidationException();
                slog.Debug(exception, "添加数据库失败");
                var fail = new Exception("添加数据库失败", exception);
                throw fail;

            }
        }
        /// <summary>
        /// 插入数据集合
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("实体集合为空");
                }
                foreach (var entity in entities)
                {
                    this.Entities.Add(entity);
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var slog = ContainerManager.Resolve<ILogger>();
                var exception = dbex.ThrowDbEntityValidationException();
                slog.Debug(exception, "添加数据库失败");
                var fail = new Exception("添加数据库失败", exception);
                throw fail;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("数据实体为空");
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var slog = ContainerManager.Resolve<ILogger>();
                var exception = dbex.ThrowDbEntityValidationException();
                slog.Debug(exception, "更新数据库失败");
                var fail = new Exception("更新数据库失败", exception);
                throw fail;

            }
        }
        /// <summary>
        /// 更新数据集合
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("实体集合为空");
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var slog = ContainerManager.Resolve<ILogger>();
                var exception = dbex.ThrowDbEntityValidationException();
                slog.Debug(exception, "更新数据库失败");
                var fail = new Exception("更新数据库失败", exception);
                throw fail;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("数据实体为空");
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var slog = ContainerManager.Resolve<ILogger>();
                var exception = dbex.ThrowDbEntityValidationException();
                slog.Debug(exception, "删除数据库失败");
                var fail = new Exception("删除数据库失败", exception);
                throw fail;

            }
        }
        /// <summary>
        /// 删除数据集合
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null) throw new ArgumentNullException("数据实体为空");
                foreach (var entity in entities)
                {
                    this.Entities.Remove(entity);
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var slog = ContainerManager.Resolve<ILogger>();
                var exception = dbex.ThrowDbEntityValidationException();
                slog.Debug(exception, "删除数据库失败");
                var fail = new Exception("删除数据库失败", exception);
                throw fail;

            }
        }
        /// <summary>
        /// 获得一张表的数据
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public virtual IQueryable<T> TableNoTracking
        {
            get { return this.Entities.AsNoTracking(); }
        }
    }
}
