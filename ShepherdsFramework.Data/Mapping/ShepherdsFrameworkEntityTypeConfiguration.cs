using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Data.Mapping
{
    /// <summary>
    /// EF code first 自关联映射
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ShepherdsFrameworkEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected ShepherdsFrameworkEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {
        }
    }


}
