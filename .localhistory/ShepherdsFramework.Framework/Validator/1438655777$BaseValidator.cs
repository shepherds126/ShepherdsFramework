using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ShepherdsFramework.Framework.Validator
{
    public abstract class BaseValidator<T>:AbstractValidator<T> where T:class 
    {
        protected BaseValidator()
        {
            Initialize()
        }

        protected virtual void Initialize()
        {

        }
    }
}
