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
        IDbSet<T> Set<T>() where T : BaseEntity;
        int SaveChanges();
    }
}


