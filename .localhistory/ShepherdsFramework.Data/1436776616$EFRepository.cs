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
            this.
        }
    }
}
