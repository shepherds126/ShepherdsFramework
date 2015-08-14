using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Data.Mapping
{
    public abstract class ShepherdsFrameworkEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {

    }


}
