using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}
