using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.Infrastructure
{
    public class AppDomainTypeFinder:ITypeFinder
    {
        public virtual AppDomain App
        {
            get { return AppDomain.CurrentDomain; }
        }

        public virtual IList<Assembly> GetAssemblies()
        {

        }
    }
}
