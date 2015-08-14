using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register();
        int Order { get;  }
    }
}
