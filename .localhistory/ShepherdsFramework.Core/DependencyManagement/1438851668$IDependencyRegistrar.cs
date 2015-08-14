﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Infrastructure;

namespace ShepherdsFramework.Core.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder,ITypeFinder typeFinder);
        int Order { get;  }
    }
}
