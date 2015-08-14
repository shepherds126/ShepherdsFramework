using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ShepherdsFramework.Framework.Validator
{
    /// <summary>
    /// 实体模型验证抽象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValidator<T>:AbstractValidator<T> where T:class 
    {
        /// <summary>
        /// 
        /// </summary>
        protected BaseValidator()
        {
            Initialize();
        }
        /// <summary>
        /// 子类可以根据不同的实体模型重写
        /// </summary>
        protected virtual void Initialize()
        {

        }
    }
}
