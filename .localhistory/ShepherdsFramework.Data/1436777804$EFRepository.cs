using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;

namespace ShepherdsFramework.Data
{
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
                var msg = string.Empty;
                foreach (var validationErrors in dbex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property:{0} Error:{1}",validationError.PropertyName,validationError.ErrorMessage)+Environment.NewLine;
                    }
                }

                var fail = new Exception(msg,dbex);
            }
        }
    }
}
