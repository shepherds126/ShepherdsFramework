﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ShepherdsFramework.Core.Infrastructure
{
    /// <summary>
    /// 依赖注入初始化器
    /// </summary>
    public class InitDependencyContainer
    {
        public static void InitContainer()
        {
            var builder = new ContainerBuilder();

        }
    }
}
